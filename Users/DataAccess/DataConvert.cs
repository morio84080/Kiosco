using System;
using System.Data;
using Users.Entities;

namespace Users.DataAccess
{
    public class DataConvert
    {
        public DataConvert()
        {
        }

        #region Users


        public static UserEntity[] ToUserCollection(DataSet ds)
        {
            int n;
            UserEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new UserEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToUser(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new UserEntity[0];
                return ret;
            }
        }

        public static UserEntity ToUser(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToUser(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static UserEntity ToUser(DataRow dr)
        {
            UserEntity ret = new UserEntity();

            ret.CodigoVend = Convert.ToInt32(dr["CodiVend"]);
            ret.PerfilVend = Convert.ToInt32(dr["PerfilVend"]);
            ret.EstaVend = Convert.ToBoolean(dr["EstaVend"]);
            ret.ApelVend = Convert.ToString(dr["ApelVend"]);
            ret.NombVend = Convert.ToString(dr["NombVend"]);
            ret.DireVend = Convert.ToString(dr["DireVend"]);
            ret.TeleVend = Convert.ToString(dr["TeleVend"]);
            ret.UserVend = Convert.ToString(dr["UserVend"]);
            ret.PassVend = Convert.ToString(dr["PassVend"]);
            ret.NombPerfil = Convert.ToString(dr["NombPerfi"]);

            return ret;
        }


        #endregion

        #region ActionCategory


        public static ActionEntity[] ToActionCategoryCollection(DataSet ds)
        {
            int n;
            ActionEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new ActionEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToActionCategory(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new ActionEntity[0];
                return ret;
            }
        }

        public static ActionEntity ToActionCategory(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToActionCategory(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static ActionEntity ToActionCategory(DataRow dr)
        {
            ActionEntity ret = new ActionEntity();

            ret.CodAcc = Convert.ToInt32(dr["CodAcc"]);
            ret.NombAcc = Convert.ToString(dr["NombAcc"]);

            return ret;
        }


        #endregion

        #region Profile


        public static ProfileEntity[] ToProfileCollection(DataSet ds)
        {
            int n;
            ProfileEntity[] ret;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection rows = ds.Tables[0].Rows;
                ret = new ProfileEntity[rows.Count];
                n = ret.GetLength(0);

                for (int i = 0; i < n; i++)
                {
                    ret[i] = ToProfile(rows[i]);
                }
                return ret;
            }
            else
            {
                ret = new ProfileEntity[0];
                return ret;
            }
        }

        public static ProfileEntity ToProfile(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ToProfile(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static ProfileEntity ToProfile(DataRow dr)
        {
            ProfileEntity ret = new ProfileEntity();

            ret.CodiPerfi = Convert.ToInt32(dr["CodiPerfi"]);
            ret.NombPerfi = Convert.ToString(dr["NombPerfi"]);
            ret.EnabledPerfi = Convert.ToBoolean(dr["EnabledPerfi"]);

            return ret;
        }


        #endregion
    }
}
