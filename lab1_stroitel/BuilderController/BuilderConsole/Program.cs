using System;
using System.Collections.Generic;
using Model;
using Microsoft.Extensions.DependencyInjection;

namespace BuilderConsole
{
    class Program
    {
        private static void Main(string[] args)
        {

            IBuilderService builderService = new BuilderService();
            BuilderModel builder = builderService.AddBuilder(131, "Виталик", false, 32, 5);

            
            Console.WriteLine(builderService.GetStatus(builder));
            
            builderService.GoWork(builder);
            Console.WriteLine(builderService.GetStatus(builder));

            builderService.PutBricks(builder, 12);
            Console.WriteLine(builderService.GetBricksNum(builder));
        }
    }
}