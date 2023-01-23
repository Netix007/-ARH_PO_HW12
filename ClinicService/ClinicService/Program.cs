using ClinicService.Services.Impl;
using ClinicService.Services;
using System.Data.SQLite;

namespace ClinicService
{
    /// <summary>
    /// https://sqlitestudio.pl/
    /// https://www.sqlite.org/datatype3.html
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //ConfigureSqlLiteConnection();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Singleton - одиночка, сервис создаетс€ только один раз, существует в единственном экземпл€ре.
            // Scoped - объект создаетс€ при каждом клиентском запросе

            builder.Services.AddScoped<IPetRepository, PetRepository>();
            builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(config =>
            {
                config.EnableAnnotations();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void ConfigureSqlLiteConnection()
        {
            string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);
            sQLiteConnection.Open();
            PrepareSchema(sQLiteConnection);
        }

        private static void PrepareSchema(SQLiteConnection sQLiteConnection)
        {
            SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
            sQLiteCommand.CommandText = "DROP TABLE IF EXISTS Consultations";
            sQLiteCommand.ExecuteNonQuery();
            sQLiteCommand.CommandText = "DROP TABLE IF EXISTS Pets";
            sQLiteCommand.ExecuteNonQuery();
            sQLiteCommand.CommandText = "DROP TABLE IF EXISTS Clients";
            sQLiteCommand.ExecuteNonQuery();

            sQLiteCommand.CommandText =
                    @"CREATE TABLE Clients(
                    ClientId INTEGER PRIMARY KEY,
                    Document TEXT,
                    SurName TEXT,
                    FirstName TEXT,
                    Patronymic TEXT,
                    Birthday INTEGER)";
            sQLiteCommand.ExecuteNonQuery();
            sQLiteCommand.CommandText =
                    @"CREATE TABLE Pets(
                    PetId INTEGER PRIMARY KEY,
                    ClientId INTEGER,
                    Name TEXT,
                    Birthday INTEGER)";
            sQLiteCommand.ExecuteNonQuery();
            sQLiteCommand.CommandText =
                    @"CREATE TABLE Consultations(
                    ConsultationId INTEGER PRIMARY KEY,
                    ClientId INTEGER,
                    PetId INTEGER,
                    ConsultationDate INTEGER,
                    Description TEXT)";
            sQLiteCommand.ExecuteNonQuery();


        }

    }
}