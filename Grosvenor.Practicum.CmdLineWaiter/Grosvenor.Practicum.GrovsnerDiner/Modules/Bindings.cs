using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Ninject.Modules;
using Ninject.Injection;


namespace Grosvenor.Practicum.GrovsnerDiner
{
    public class LibraryBindings : NinjectModule
    {
        public override void Load()
        {

            Kernel.Bind<IRepository<Dish>>().To<Repository<Dish>>();
            Kernel.Bind<IDinerService>().To<DinerService>();
            Kernel.Bind<IFoodServer>().To<FoodServer>();
        }
    }
}
