﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector;
using Persistencia.Producto;
using Persistencia.Proveedor;
using Persistencia.Compras;

namespace Presentacion
{
    static class Program
    {
        public static Container container;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<Form1>());
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container();

            // Register your types, for instance:
            container.Register<IProductoCommandsHandler, ProductoCommandsHandler>(Lifestyle.Singleton);
            container.Register<IProveedorCommandsHandler, ProveedorCommandsHandler>(Lifestyle.Singleton);
            container.Register<IComprasCommandsHandler, ComprasCommandsHandler>(Lifestyle.Singleton);
            //container.Register<IProveedorQueryHandler, frm_AdminProveedor>();
            // container.Register<frm_AdminProveedor>();

            // Optionally verify the container.
            //container.Verify();
        }

    }
}
