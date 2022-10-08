
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Task.Application.UserCases.Employees.Commands.Create;
using Task.Application.UserCases.Employees.Commands.Delete;
using Task.Application.UserCases.Employees.Commands.Update;
using Task.Application.UserCases.Employees.Queries.GetAll;
using Task.Application.UserCases.Employees.Queries.GetById;
using Task.Application.UserCases.Login;
using Task.Common;
using Task.Domain.ApplicationUser;
using Task.Domain.Common;
using Task.Presistence.Core;
using Task.Presistence.IRepositories;
using Task.Presistence.Repositories;

namespace Task
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee CRUD", Version = "v1" });
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });



            //identity context
            services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
              );

            //jwt section
            var jwtSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSection);


            //to validate the token which has been sent by clients
            var appSettings = jwtSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateActor = false,
                    //ValidateSignatureLast = false,
                    ValidateTokenReplay = false,
                    //ValidateWithLKG = false,
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddAuthorization();
            services.AddCors();
            //end

            //injection 
            services.AddScoped<ICreateEmployeeCommand, CreateEmployeeCommand>();
            services.AddScoped<IUpdateEmployeeCommand, UpdateEmployeeCommand>();
            services.AddScoped<IDeleteEmployeeCommand, DeleteEmployeeCommand>();
            services.AddScoped<IGetAllEmployeeQuery, GetAllEmployeesQuery>();
            services.AddScoped<IGetEmployeeByIdQuery, GetEmployeeByIdQuery>();

            //login
            services.AddScoped<ILoginCommand, LoginCommand>();

            //repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
          
            // Register Swagger Services 
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Employee CRUD", Version = "v1" });
             

                //c.OperationFilter<CustomHeaderSwaggerAttribute>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                });

                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });

                c.DocInclusionPredicate((name, api) => true);

                c.OperationFilter<AddAuthHeaderOperationFilter>();


            });
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee CREUD v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Authorization && Authentication
            app.UseAuthentication();
            app.UseAuthorization();

            //you need change the origin when you deploy the front end with new url to it 
            app.UseCors(policy => policy.AllowAnyHeader()
                                       .AllowAnyMethod()
                                       .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
