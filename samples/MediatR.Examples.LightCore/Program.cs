using LightCore;
using MediatR;
using MediatR.LightCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Examples.LightCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new WrappingWriter(Console.Out);
            var mediator = BuildMediator(writer);

            Runner.Run(mediator, writer, "LightCore").Wait();
        }

        private static IMediator BuildMediator(WrappingWriter writer)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new MediatRModule(typeof(Runner).Assembly));

            builder.Register<System.IO.TextWriter>(ctn => writer);
            var container = builder.Build();

            return container.Resolve<IMediator>();
        }
    }
}
