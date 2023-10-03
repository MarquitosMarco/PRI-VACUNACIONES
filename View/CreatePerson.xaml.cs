using Microsoft.Data.SqlClient;
using System.Data;
using tag1.Model;
using tag1.ViewModel;

namespace tag1.View;

public partial class CreatePerson : ContentPage
{
    private PersonViewModel _viewModel;
    public CreatePerson()
	{
		InitializeComponent();
        _viewModel = new PersonViewModel(); // Crea una instancia de tu ViewModel

        BindingContext = _viewModel;
    }


}