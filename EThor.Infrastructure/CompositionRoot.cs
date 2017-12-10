using EThor.Core.DataAccess;
using EThor.DataAccess;
using Ninject;
using Ninject.Modules;
using EThor.ApplicationService;
using EThor.Core;

namespace EThor.Infrastructure
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }

    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IDataProvider)).To(typeof(DataProvider));
            Bind(typeof(IOperationEngine)).To(typeof(OperationEngine));
            Bind(typeof(IOperationService)).To(typeof(OperationService));
        }
    }
}
