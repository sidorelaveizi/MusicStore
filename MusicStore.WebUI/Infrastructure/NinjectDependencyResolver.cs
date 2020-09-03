using Moq;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            Mock<IAlbumRepository> mock = new Mock<IAlbumRepository>();
            mock.Setup(m => m.Albums).Returns(new List<Album> {
new Album { Title = "Football", Price = 25, AlbumArtUrl="fvfdg"},
new Album { Title = "Surf board", Price = 179 },
new Album { Title = "Running shoes", Price = 95 }
});
            kernel.Bind<IAlbumRepository>().ToConstant(mock.Object);
        }
    }
}