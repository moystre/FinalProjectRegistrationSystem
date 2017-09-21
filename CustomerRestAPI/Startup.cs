using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;

namespace CustomerRestAPI
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                /*var facade = new BLLFacade();

                var address1 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Kolding",
                        Street = "SomeStreet",
                        Number = "21"
                    });

                var address2 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Esbjerg",
                        Street = "AnotherStreet",
                        Number = "666"
                    });

                var address3 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Dank",
                        Street = "Memes",
                        Number = "21"
                    });

                var cust = facade.CustomerService.Create(new CustomerBO()
                {
                    FirstName = "Mark",
                    LastName = "Palmai",
                    AddressIds = new List<int>() { address1.Id, address2.Id }
                });

                facade.CustomerService.Create(new CustomerBO()
                {
                    FirstName = "Yo",
                    LastName = "Momma",
                    AddressIds = new List<int>() { address3.Id }
                });

                for (int i = 0; i < 5; i++)
                {
                    facade.OrderService.Create(new OrderBO()
                    {
                        DeliveryDate = DateTime.Now.AddMonths(1),
                        OrderDate = DateTime.Now.AddMonths(-1),
                        CustomerId = cust.Id
                    });
                }*/
            }

            app.UseMvc();
        }
    }
}
