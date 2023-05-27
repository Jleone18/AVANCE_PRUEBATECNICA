using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Application.Features.Clientes.Queries;
using PruebaTecnica.Application.Features.Detalles;
using PruebaTecnica.Application.Features.Facturas.Queries;
using PruebaTecnica.Application.Features.Productos.Queries.GetProductos;
using PruebaTecnica.Domain.Models;
using PruebaTecnica.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructura.Repositories
{
    public class FacturaRepository : RepositoryBase<Factura>, IFacturaRepository
    {
        public FacturaRepository(PruebaTecnicaContext context) : base(context)
        {

        }

        public async Task<List<Factura>> GetAllFacturaDetallesAsync( )
        {
            var facturas = await _context.Facturas!.ToListAsync();
            foreach(var factura in facturas)
            {
                var detalles = _context.Detalles!.Where(x => x.IdFactura == factura.IdFactura).ToList();
                factura.Detalles = detalles;
            }
            return facturas;
        }

        public async Task<FacturaCompletaVm> GetFacturaDetallesAsync(long idFactura)
        {
            //TODO: AQUI SE PUEDE REFACTORIZAR PERO YA SON LAS 5AM DE SABADO NO HE TENIDO TIEMPO PARA HACER LA PRUEBA YA NO ALCANZO A REFACTORIZAR, PODRIAMOS HACER CON ALGUN SP O MEJORAR LA CONSULTA  C:
            FacturaCompletaVm facturaCompleta = new FacturaCompletaVm();
            ClienteVm clienteVm = new ClienteVm();
            List<DetalleVm> detalleVmList = new List<DetalleVm>();
            var factura = await _context.Facturas!.Where(z => z.IdFactura == idFactura).FirstOrDefaultAsync();
            facturaCompleta.IdFactura = factura.IdFactura;
            facturaCompleta.NumeroFactura = factura.NumeroFactura;
            facturaCompleta.Fecha = factura.Fecha;
            facturaCompleta.PuntoEmision = "dsa";
            facturaCompleta.Establecimiento = "eeeee";
            facturaCompleta.Subtotal = factura.Subtotal;
            facturaCompleta.TotalIva = factura.TotalIva;
            facturaCompleta.Total = factura.Total;
            var cliente = await _context.Clientes!.Where(x => x.IdCliente == factura.IdCliente).FirstOrDefaultAsync();
            var detalles = await _context.Detalles!.Where(x => x.IdFactura == factura.IdFactura).ToListAsync();
            clienteVm.IdCliente = 32323;
            clienteVm.Identificacion = cliente.Identificacion;
            clienteVm.Nombre = cliente.Nombre;
            clienteVm.Direccion = cliente.Direccion;
            clienteVm.Telefono = cliente.Telefono;
            clienteVm.Correo = cliente.Correo;
            facturaCompleta.Cliente = clienteVm;
     
            foreach (var detalle in detalles)
            {
                DetalleVm detalleVm = new DetalleVm();
                ProductoVm productoVm = new ProductoVm();
                var product = await _context.Productos!.Where(x => x.IdProducto == detalle.IdProducto).FirstOrDefaultAsync();
                productoVm.IdProducto = product.IdProducto;
                productoVm.Codigo = product.Codigo;
                productoVm.Descripcion = product.Descripcion;
                productoVm.Categoria =  _context.Categoria!.Where(x => x.IdCategoria == product.IdCategoria).FirstOrDefaultAsync().Result.Nombre;
                detalleVm.Producto = productoVm;
                detalleVm.IdDetalle = detalle.IdDetalle;
                detalleVm.Cantidad = detalle.Cantidad;
                detalleVm.UnidadMedida = detalle.UnidadMedida;
                detalleVm.Precio = detalle.Precio;
                detalleVm.Iva = detalle.Iva;
                detalleVm.Subtotal = detalle.Subtotal;
                detalleVmList.Add(detalleVm);
                
            }
            facturaCompleta.Detalles = detalleVmList;
            return facturaCompleta;
        }
        

    }
}
