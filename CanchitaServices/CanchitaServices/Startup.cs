﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Application.Services;
using CanchitaServices.Models;
using CanchitaServices.Models.Repositories;
using Domain;
using Domain.IRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infraestructure.Persistencia;
using Infraestructure.Repositories;
using Infraestructure.Transversal.FluentValidations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;


namespace CanchitaServices
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
            services.AddDbContext<CanchitaDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:Canchita:ConnectionString"]));            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:CanchitaIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores <AppIdentityDbContext>()
            .AddDefaultTokenProviders();            services.AddTransient<IClienteRepository, EFClienteRepository>();            services.AddTransient<IDepartamentoRepository, EFDepartamentoRepository>();            services.AddTransient<IProvinciaRepository, EFProvinciaRepository>();            services.AddTransient<IDistritoRepository, EFDistritoRepository>();            services.AddTransient<ILocalRepository, EFLocalRepository>();
            services.AddTransient<IServicioRepository, EFServicioRepository>();
            services.AddTransient<ILocalServicioRepository, EFLocalServicioRepository>();
            services.AddTransient<IImagenRepository, EFImagenRepository>();
            services.AddTransient<ICanchaRepository, EFCanchaRepository>();
            services.AddTransient<ITurnoRepository, EFTurnoRepository>();
            services.AddTransient<IPrecioRepository, EFPrecioRepository>();
            services.AddTransient<IAlquilerRepository, EFAlquilerRepository>();

            //DE LOS SERVICIOS
            services.AddTransient<IDepartamentoServices, DepartamentoService>();            services.AddTransient<IProvinciaService, ProvinciaService>();            services.AddTransient<IDistritoService, DistritoService>();            services.AddTransient<ILocalService, LocalService>();            services.AddTransient<IServicioService, ServicioService>();
            services.AddTransient<IClienteService, ClienteService>();

            services.AddTransient<ICanchaService, CanchaService>();
            services.AddTransient<IAlquilerService, AlquilerService>();

            services.AddTransient<ILocalServicioService, LocalServicioService>();
            services.AddTransient<IImagenService, ImagenService>();
            services.AddTransient<ITurnoService, TurnoService>();
            services.AddTransient<IPrecioService, PrecioService>();
           


            //Validators 
            services.AddTransient<IValidator<DepartamentoDTO>, DepartamentoDTOValidator>();
            services.AddTransient<IValidator<ServicioDTO>, ServicioDTOValidator>();
            services.AddTransient<IValidator<LocalServicioDTO>, LocalServicioDTOValidator>();
            services.AddTransient<IValidator<ImagenDTO>, ImagenDTOValidator>();
            services.AddTransient<IValidator<ProvinciaDTO>, ProvinciaDTOValidator>();
            services.AddTransient<IValidator<DistritoDTO>, DistritoDTOValidator>();
            services.AddTransient<IValidator<LocalDTO>, LocalDTOValidator>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "CanchitaServices", Version = "v1" });
            });
            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            /*else
            {
                app.UseHsts();
            }
            //por si acaso otra vez jejeej xd
            app.UseHttpsRedirection();*/
            app.UseAuthentication();
            app.UseMvc();
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}
