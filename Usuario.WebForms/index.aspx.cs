using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using Usuario.WebForms.Data;
using Usuario.WebForms.Model;

namespace Usuario.WebForms
{
    public partial class index : System.Web.UI.Page
    {
        public List<Usuarios> UsuariosList { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            RecarregarGrid();
        }

        #region Campos e Botoes
        private void ConfigurarBotoes(bool exibir)
        {
            btnInserir.Visible = exibir;
            btnAlterar.Visible = !exibir;
            btnExcluir.Visible = !exibir;
        }

        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtMae.Text = string.Empty;
            txtPai.Text = string.Empty;
            txtDataNascimento.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            ConfigurarBotoes(true);
            ExibirMensagemErro(false);
        }

        private void PreencherCampos(int id)
        {
            foreach (var user in UsuariosList.Where(u => u.Id == id))
            {
                txtId.Text = user.Id.ToString();
                txtNome.Text = user.Nome;
                txtEmail.Text = user.Email;
                txtTelefone.Text = user.Telefone;
                txtMae.Text = user.NomeMae;
                txtPai.Text = user.NomePai;
                txtDataNascimento.Text = user.DataNascimento.ToString("dd/MM/yyyy");
                txtDocumento.Text = user.Documento;
            }
        }
        #endregion Campos e Botoes

        #region MensagemErro
        private void ExibirMensagemErro(bool exibir)
        {
            lblMsg.Visible = exibir;
        }
        #endregion MensagemErro

        #region Validacao        
        private bool ValidarForm()
        {
            if (!ValidarCamposNumericos(txtTelefone.Text.Trim()))
            {
                lblMsg.Text = "Telefone deve conter somente números";
                ExibirMensagemErro(true);
                return false;
            }

            if (!ValidarCamposNumericos(txtDocumento.Text.Trim()))
            {
                lblMsg.Text = "Documento deve conter somente números";
                ExibirMensagemErro(true);
                return false;
            }

            if (!ValidarData(txtDataNascimento.Text.Trim()))
            {
                lblMsg.Text = "Data Inválida";
                ExibirMensagemErro(true);
                return false;
            }

            if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Length < 3)
            {
                lblMsg.Text = "Nome deve ter pelo menos 3 caracteres";
                ExibirMensagemErro(true);
                return false;
            }
            else if (txtEmail.Text.Trim() == string.Empty || !txtEmail.Text.Contains("@") || !txtEmail.Text.Contains(".com"))
            {
                lblMsg.Text = "E-mail inválido";
                ExibirMensagemErro(true);
                return false;
            }
            else if (txtMae.Text.Trim() == string.Empty || txtMae.Text.Length < 3)
            {
                lblMsg.Text = "Nome da Mãe deve ter pelo menos 3 caracteres";
                ExibirMensagemErro(true);
                return false;
            }

            ExibirMensagemErro(false);
            return true;
        }

        private bool ValidarCamposNumericos(string campo)
        {
            var somenteNumeros = string.Join("", System.Text.RegularExpressions.Regex.Split(campo, @"[^\d]"));
            if (somenteNumeros.Length != campo.Length)
                return false;
            else
                return true;
        }

        private bool ValidarData(string campo)
        {
            DateTime valor;
            var dataConvertida = DateTime.TryParseExact(campo, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out valor);

            if (dataConvertida)
                return true;
            else
                return false;
        }
        #endregion Validacao

        #region Grid
        private void RecarregarGrid()
        {
            DataTable dt = new DataTable();
            dt = Conexao.GetAllUsuarios();
            UsuariosList = new List<Usuarios>();
            UsuariosList = (from DataRow dr in dt.Rows
                            select new Usuarios()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nome = dr["Nome"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefone = dr["Telefone"].ToString(),
                                NomeMae = dr["NomeMae"].ToString(),
                                NomePai = dr["NomePai"].ToString(),
                                Documento = dr["Documento"].ToString(),
                                DataNascimento = Convert.ToDateTime(dr["DataNascimento"])
                            }
                       ).ToList();

            GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
        }
        #endregion Grid

        #region Componentes
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                try
                {
                    Usuarios usuario = new Usuarios()
                    {
                        Nome = txtNome.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Telefone = txtTelefone.Text.Trim(),
                        NomeMae = txtMae.Text.Trim(),
                        NomePai = txtPai.Text.Trim(),
                        Documento = txtDocumento.Text.Trim(),
                        DataNascimento = Convert.ToDateTime(txtDataNascimento.Text.Trim())
                    };
                    Conexao.Add(usuario);
                    LimparCampos();
                }
                catch (Exception)
                {
                    lblMsg.Text = string.Format("Erro ao inserir o usuário {0}", txtNome.Text);
                }
            }
            RecarregarGrid();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() != string.Empty)
            {
                if (ValidarForm())
                {
                    try
                    {
                        Usuarios usuario = new Usuarios()
                        {
                            Id = Convert.ToInt32(txtId.Text.Trim()),
                            Nome = txtNome.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Telefone = txtTelefone.Text.Trim(),
                            NomeMae = txtMae.Text.Trim(),
                            NomePai = txtPai.Text.Trim(),
                            Documento = txtDocumento.Text.Trim(),
                            DataNascimento = Convert.ToDateTime(txtDataNascimento.Text.Trim())
                        };
                        Conexao.Update(usuario);
                        LimparCampos();
                    }
                    catch (Exception)
                    {
                        lblMsg.Text = string.Format("Erro ao alterar o usuário {0}", txtNome.Text);
                    }
                }
                RecarregarGrid();
            }
            else
            {
                lblMsg.Text = "Deve selecionar um usuário para alteração!";
                ExibirMensagemErro(true);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() != string.Empty)
            {
                try
                {
                    Conexao.Delete(Convert.ToInt32(txtId.Text.Trim()));
                    LimparCampos();
                }
                catch (Exception)
                {
                    lblMsg.Text = string.Format("Erro ao excluir o usuário {0}", txtNome.Text);
                }
                RecarregarGrid();
            }
            else
            {
                lblMsg.Text = "Deve selecionar um usuário para exclusão!";
                ExibirMensagemErro(true);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void GridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherCampos(Convert.ToInt32(GridUsuario.SelectedRow.Cells[0].Text));
            ConfigurarBotoes(false);
        }
        #endregion Componentes
    }
}