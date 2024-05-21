using JJAENT5.Models;
using System.Xml.Linq;

namespace JJAENT5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}
    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(TxtName.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
        
    }
    private void btnObtener_Clicked(object sender, EventArgs e)
    {
         lblStatus.Text = "";
         List<Persona>people=App.personRepo.getAllPeople();
         ListarPersona.ItemsSource = people;
        //ListarPersona.ItemsSource=people;
        lblStatus.Text = App.personRepo.StatusMessage;

        
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null && button.CommandParameter is int id)
        {
            var result = App.personRepo.DeletePerson(id);
            lblStatus.Text = result ? "Persona eliminada correctamente." : "Error al eliminar la persona.";
        }
        else
        {
            lblStatus.Text = "Error al obtener el ID de la persona.";
        }

    }
    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null && button.CommandParameter is int id)
        {
            var newName = TxtName.Text; 

            if (string.IsNullOrEmpty(newName))
            {
                lblStatus.Text = "Por favor, ingrese un nuevo nombre.";
                return;
            }

            var result = App.personRepo.UpdatePersonName(id, newName);
            lblStatus.Text = result ? "Nombre de persona actualizado correctamente." : "Error al actualizar el nombre de la persona.";
        }
        else
        {
            lblStatus.Text = "Error al obtener el ID de la persona.";
        }
    }



}
    
   
