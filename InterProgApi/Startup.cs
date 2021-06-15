using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InterProgApi.Data;
using InterProgApi.helpers;
using InterProgApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace InterProgApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            using (DatabaseContext context = new DatabaseContext())
            {
                if (context.Users.ToList().Count == 0)
                {
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"InitData\users.json"));
                    foreach (var user in users)
                    {
                        user.Password = MyEncoder.ComputeSha256Hash(user.Password);
                    }
                    context.Users.AddRange(users);    
                }

                if (context.Courses.ToList().Count == 0)
                {
                    Course newCourse = new Course(){
                        Name = "c++",
                        Description = "Learn smth about c++",
                        Problems = new List<Problem>{
                            new Problem(){
                                Name = "Summator",
                                Description = "Add two nums, lol",
                                TestJson = new TestInput()
                                {
                                    Format = "^\\d+(.\\d+)?\\+\\d+(.\\d+)?=(?<1>-?\\d+(.\\d+)?)\\s+$",
                                    Time = 1000,
                                    Tests = new List<SingleTestInput>{
                                        new SingleTestInput(){
                                            Name = "test1",
                                            Input = new List<object>{"1","2"},
                                            Output = new List<object>{"3"}
                                        },
                                        new SingleTestInput(){
                                            Name = "test2",
                                            Input = new List<object>{"3","4"},
                                            Output = new List<object>{"7"}
                                        },
                                        new SingleTestInput(){
                                            Name = "test3",
                                            Input = new List<object>{"0","-100"},
                                            Output = new List<object>{"-100"}
                                        },
                                        new SingleTestInput(){
                                            Name = "test4",
                                            Input = new List<object>{"1.2","2.2"},
                                            Output = new List<object>{"3.4"}
                                        }
                                    }
                                }
                            }
                        }
                    };
                    context.Courses.Add(newCourse);    
                }

                context.SaveChanges();
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DatabaseContext>();

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });
        }
    }
}
