using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBUS
    {
        //private UserDAO _userDAO;

        ///// <constructor>
        ///// Constructor UserBUS
        ///// </constructor>
        //public UserBUS()
        //{
        //    _userDAO = new UserDAO();
        //}

        ///// <method>
        ///// Get User Email By Firstname or Lastname and return VO
        ///// </method>
        //public UserVO getUserEmailByName(string name)
        //{
        //    UserVO userVO = new UserVO();
        //    DataTable dataTable = new DataTable();

        //    dataTable = _userDAO.searchByName(name);

        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        userVO.idUser = Int32.Parse(dr["t01_id"].ToString());
        //        userVO.firstname = dr["t01_firstname"].ToString();
        //        userVO.lastname = dr["t01_lastname"].ToString();
        //        userVO.email = dr["t01_email"].ToString();
        //    }
        //    return userVO;
        //}

        ///// <method>
        ///// Get User Email By Id and return DataTable
        ///// </method>
        //public UserVO getUserById(string _id)
        //{
        //    UserVO userVO = new UserVO();
        //    DataTable dataTable = new DataTable();
        //    dataTable = _userDAO.searchById(_id);

        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        userVO.idUser = Int32.Parse(dr["t01_id"].ToString());
        //        userVO.firstname = dr["t01_firstname"].ToString();
        //        userVO.lastname = dr["t01_lastname"].ToString();
        //        userVO.email = dr["t01_email"].ToString();
        //    }
        //    return userVO;
        }
    }
