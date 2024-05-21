using JJAENT5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JJAENT5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

    public void Init() {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }
        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona person = new() { Name= name };
                result = conn.Insert(person);
                StatusMessage = string.Format("Se inserto una persona", result, name);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("error no se inserto", name, ex.Message);
            }
        }
        public List<Persona> getAllPeople() {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("error en la lista", ex.Message);
            }
            return new List<Persona>();

        }
        public bool DeletePerson(int id)
        {
            try
            {
                Init();
                int result = conn.Delete<Persona>(id);
                if (result > 0)
                {
                    StatusMessage = "Persona eliminada correctamente.";
                    return true;
                }
                else
                {
                    StatusMessage = "No se encontró la persona para eliminar.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar persona: {0}", ex.Message);
                return false;
            }
        }
        public bool UpdatePersonName(int id, string newName)
        {
            try
            {
                Init();
                var person = conn.Find<Persona>(id);
                if (person != null)
                {
                    person.Name = newName;
                    int result = conn.Update(person);
                    if (result > 0)
                    {
                        StatusMessage = "Nombre de persona actualizado correctamente.";
                        return true;
                    }
                    else
                    {
                        StatusMessage = "No se pudo actualizar el nombre de la persona.";
                        return false;
                    }
                }
                else
                {
                    StatusMessage = "No se encontró la persona para actualizar.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar nombre de persona: {0}", ex.Message);
                return false;
            }
        }
    }

}
 




