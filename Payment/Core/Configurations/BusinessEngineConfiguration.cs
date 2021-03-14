using Business.Engine.Engines;
using Business.Engine.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Payment.Core.Configurations
{
    public static class BusinessEngineConfiguration
    {
        public static IServiceCollection ConfigureBusinessEngines(this IServiceCollection services)
        {
            services.AddScoped<IPaymentEngine, PaymentEngine>();
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPremiumPaymentGateway, PremiumPaymentGateway>();

            return services;
        }
    }
}
