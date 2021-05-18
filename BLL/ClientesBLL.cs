using Microsoft.EntityFrameworkCore;
using RegistroCliente.Data;
using RegistroCliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroCliente.BLL
{
    public class ClientesBLL
    {
        public Contexto Contexto { get; set; }

        public ClientesBLL(Contexto contexto)
        {
            this.Contexto = contexto;
        }

        public bool Insertar(Clientes clientes)
        {
            bool paso;
            if (clientes.ClienteId == 0)
            {

                paso = Guardar(clientes);
            }
            else
            {

                paso = Modificar(clientes);
            }

            return paso;
        }

        public static bool Guardar(Clientes clientes)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Clientes.Add(clientes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Clientes clientes)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(clientes).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public bool Eliminar(int Id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            Clientes clientes = contexto.Clientes.Find(Id);

            try
            {

                contexto.Entry(clientes).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public Clientes Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            Clientes clientes = new Clientes();

            try
            {

                clientes = contexto.Clientes.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return clientes;
        }
    }

}
