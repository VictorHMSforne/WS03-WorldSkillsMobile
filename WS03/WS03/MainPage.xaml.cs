using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using WS03.Servico; // adicionei
using WS03.Servico.Modelo;// adicionei

namespace WS03
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnCEP.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        lblResultado.Text = string.Format("Endereço: {2},{3},{0},{1}.", end.localidade, end.uf, end.logradouro, end.bairro);
                        txtCEP.Text = "";
                    }
                    else
                    {
                        DisplayAlert("Erro", "CEP Não Encontrado!", "Ok");
                    }
                }
                catch (Exception erro) 
                {
                    DisplayAlert("Erro", erro.Message, "Ok");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! O CEP tem apenas 8 números", "Ok");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "O CEP contém apenas números", "Ok");
                valido = false;
            }
            return valido;
        }
    }
}
