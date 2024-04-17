using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RutasTuristicas
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "metadata=res:///Model1.csdl|res:///Model1.ssdl|res:///Model1.msl;provider=System.Data.SqlClient;provider connection string=\"data source=DESKTOP-FEM7MQG\\SQLSERVER;initial catalog=RUTAS;user id=sa;password=;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework\"";
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Obtener clientes y calcular importe pagado
                SqlCommand command = new SqlCommand("SELECT IdCliente, Nombre, TipoCliente FROM Clientes", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idCliente = reader.GetInt32(0);
                    string nombreCliente = reader.GetString(1);
                    string tipoCliente = reader.GetString(2);
                    Cliente cliente = new Cliente(idCliente, nombreCliente, tipoCliente);
                    cliente.CalcularImportePagado(connection);
                    clientes.Add(cliente);
                }
                reader.Close();
            }

            // Mostrar lista de clientes y acumulado del importe pagado
            Console.WriteLine("Lista de Clientes:");
            decimal totalImportePagado = 0;
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}, Importe Pagado: {cliente.ImportePagado}");
                totalImportePagado += cliente.ImportePagado;
            }
            Console.WriteLine($"Total Importe Pagado: {totalImportePagado}");

            Console.ReadLine();
        }
    }

    class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string TipoCliente { get; set; }
        public decimal ImportePagado { get; set; }

        public Cliente(int idCliente, string nombre, string tipoCliente)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            TipoCliente = tipoCliente;
        }

        public void CalcularImportePagado(SqlConnection connection)
        {
            // Calcular importe pagado por el cliente
            // Implementa la lógica para calcular el importe pagado por este cliente en base a sus ventas
            // Puedes usar el tipo de cliente y otras condiciones para aplicar los descuentos
            // y calcular el importe total pagado
            // Luego, asigna el resultado al atributo ImportePagado
            ImportePagado = 0; // Placeholder, reemplaza con el cálculo real
        }
    }
}