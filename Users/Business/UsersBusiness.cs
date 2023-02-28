using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Users.Entities;
using Users.DataAccess;
using System.Data;
using System.Windows.Forms;

namespace Users.Business
{
    public class UsersBusiness
    {
        
        public int LoginUser(string Usuario, string Password)
        {
            try
            {
                //UsersDALC usDalc = new UsersDALC();
                int Rta = new UsersDALC().LoginUser(Usuario);
                if (Rta == 1)
                {
                    DataTable dt = new UsersDALC().Login(Usuario, Password);
                    if (dt.Rows.Count == 1)
                    {
                        if ((bool)dt.Rows[0]["EstaVend"] == false)
                        {
                            //SucursalId.IdIntSucursal = (decimal)dt.Rows[0]["idsucursal"];// representa al idInterno del al tabla Sucursales
                            ////				SucursalId.IdSucursal = (string)dt.Rows[0]["idsucursal"];
                            //AreaId.IdArea = (int)dt.Rows[0]["areaid"];
                            //Categoria = (short)dt.Rows[0]["categoriaadminid"];
                            //IdAdmin = (int)dt.Rows[0]["idadmin"];
                            //Nombre = (string)dt.Rows[0]["nombre"];
                            //Usuario = (string)dt.Rows[0]["usuario"];
                            //Password = (string)dt.Rows[0]["password"];
                            //CambioPass = (bool)dt.Rows[0]["CambioPass"];	 //(Martin)
                            //try
                            //{
                            //    IP = (string)dt.Rows[0]["IP"];		//(Martin)	
                            //}
                            //catch (System.InvalidCastException)
                            //{
                            //    IP = string.Empty;
                            //}
                            return 0;
                        }
                        else
                        {
                            return 3;
                        }
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception ex)
            { throw ex; }

        }

        public UserEntity getByUserName(string userName)
        {
            return new UsersDALC().GetByUserName(userName);
        }

        public UserEntity getAllUsers()
        {
            return new UsersDALC().GetAll();
        }

        public UserEntity getUserID(int userID)
        {
            return new UsersDALC().GetByID(userID);
        }
        public DataTable getAllUsers_DT()
        {
            return new UsersDALC().DS_GetAll().Tables[0];
        }

        public int ExistsAction(int AdminID, int ActionID)
        {
            return new UsersDALC().ExistsAction(AdminID,ActionID);
        }

        public void CategorySetAction (int CategoryID, int ActionID)
        {
            new PerfilDALC().InsertActionCateAdmin(CategoryID, ActionID);

        }

        public void CategoryDeleteAction(int CategoryID)
        {
            new PerfilDALC().DeleteActionCateAdmin(CategoryID);

        }


        public void UserInsert(UserEntity usEty)
        {
            new UsersDALC().Insert(usEty);

        }

        public void UserUpdate(UserEntity usEty)
        {
            new UsersDALC().Update(usEty);

        }


        public ActionEntity[] ActionCategoryByCateID(int CategoryID)
        {
            return new ActionDALC().GetByCateID(CategoryID);
        }

        public DataTable DT_ActionCategoryByCateID(int CategoryID)
        {
            DataTable dt = new DataTable();
            ActionDALC acDALC = new ActionDALC();
            dt= acDALC.DT_GetByCateID(CategoryID).Tables[0];
            return dt;
        }

        public DataTable CategoryAdminGetAll()
        {
            PerfilDALC catDALC = new PerfilDALC();
            return catDALC.GetAll().Tables[0];
        }

        public DataTable CategoryAdminGetAllAux()
        {
            PerfilDALC catDALC = new PerfilDALC();
            return catDALC.GetAllAux().Tables[0];
        }

        public int LlenarComboBox(ComboBox cbo)
        {
            //UsersBusiness usBus = new UsersBusiness();
            try
            {
                cbo.DataSource = this.CategoryAdminGetAll();
                cbo.DisplayMember = "nameii";
                cbo.ValueMember = "CategoryID";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al listar los perfiles");
                return -1;

            }

        }

        public int LlenarComboBoxAux(ComboBox cbo)
        {
            try
            {
                cbo.DataSource = this.CategoryAdminGetAllAux();
                cbo.DisplayMember = "nameii";
                cbo.ValueMember = "CategoryID";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al listar los perfiles");
                return -1;

            }

        }

    }
}
