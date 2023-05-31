using AutoMapper;
using PruebaTecnica.Application.Features.Cajas.Command.Create;
using PruebaTecnica.Application.Features.Cajas.Command.Update;
using PruebaTecnica.Application.Features.Cajas.Queries;
using PruebaTecnica.Application.Features.Categorias.Command.Create;
using PruebaTecnica.Application.Features.Categorias.Command.Update;
using PruebaTecnica.Application.Features.Categorias.Queries;
using PruebaTecnica.Application.Features.Clientes.Command.Create;
using PruebaTecnica.Application.Features.Clientes.Command.Update;
using PruebaTecnica.Application.Features.Clientes.Queries;
using PruebaTecnica.Application.Features.Detalles;
using PruebaTecnica.Application.Features.Establecimientos.Command.Create;
using PruebaTecnica.Application.Features.Facturas;
using PruebaTecnica.Application.Features.Facturas.Commands.Create;
using PruebaTecnica.Application.Features.Facturas.Commands.Update;
using PruebaTecnica.Application.Features.Facturas.Queries;
using PruebaTecnica.Application.Features.Productos.Command.Create;
using PruebaTecnica.Application.Features.Productos.Command.Update;
using PruebaTecnica.Application.Features.Productos.Queries.GetProductos;
using PruebaTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Utilitis.Mappings
{
    class Mapping : Profile
    {
        public Mapping()
        {
            
            CreateMap<Factura, FacturaVm>();
          
            CreateMap<Factura, FacturaCompletaVm>();
            CreateMap<Categoria, CategoriaVm>();
            CreateMap<Producto, ProductoVm>();
            CreateMap<Caja, CajaVm>();
            CreateMap<Cliente, ClienteVm>();

            CreateMap<Detalle, DetalleVm>().ReverseMap();
            CreateMap<Detalle, DetalleVm2>().ReverseMap();

            CreateMap<CreateCategoriaCommand, Categoria>();
            CreateMap<CreateCajaCommand, Caja>();
            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<CreateEstablecimientoCommand, Establecimiento>();
            CreateMap<CreateFacturaCommand, Factura>();
            CreateMap<CreateProductoCommand, Producto>();



            CreateMap<UpdateCategoriaCommand, Categoria>();
            CreateMap<UpdateCajaCommand, Caja>();
            CreateMap<UpdateClienteCommand, Cliente>();
            CreateMap<UpdateProductoCommand, Producto>();
            CreateMap<UpdateFacturaCommand, Factura>();
        }
    }
}
