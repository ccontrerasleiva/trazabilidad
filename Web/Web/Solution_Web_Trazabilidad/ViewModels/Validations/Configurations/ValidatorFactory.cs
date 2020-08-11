namespace ViewModels.Validations.Configurations
{
    using FluentValidation;
    using System;
    using System.Collections.Generic;

    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            //validators.Add(typeof(IValidator<Models.Schedule>), new Schedule());
            //validators.Add(typeof(IValidator<Models.Client>), new Client());
            //validators.Add(typeof(IValidator<Models.Service>), new Service());
            //validators.Add(typeof(IValidator<Models.Locomotive>), new Locomotive());
            //validators.Add(typeof(IValidator<Models.Estacion>), new Estacion());
            //validators.Add(typeof(IValidator<Models.TravelTime>), new TravelTime());
            //validators.Add(typeof(IValidator<Models.PassengerTravelTime>), new PassengerTravelTime());
            //validators.Add(typeof(IValidator<Models.Route>), new Route());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (validators.TryGetValue(validatorType, out IValidator validator))
            {
                return validator;
            }
            return validator;
        }
    }
}