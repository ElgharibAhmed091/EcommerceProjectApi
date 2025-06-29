using Stripe;
using Stripe.Checkout;

namespace EcommerceProAPI.Models
{
    public class StripeService
    {
        private readonly IConfiguration _config;

        public StripeService(IConfiguration config)
        {
            _config = config;
            StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];
        }

        public Session CreateCheckoutSession(List<SessionLineItemOptions> lineItems)
        {
            var options = new SessionCreateOptions
            {
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7072/api/stripe/payment-success",
                CancelUrl = "https://localhost:7072/api/stripe/payment-cancel"
            };


            var service = new SessionService();
            return service.Create(options);
        }
    }
}
