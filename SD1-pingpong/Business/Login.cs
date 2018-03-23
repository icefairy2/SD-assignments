using Dao;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Login
    {
        private UserDAO _userDAO;

        public Login()
        {
            _userDAO = new UserDAO();
        }


        public User Execute(string email, string password)
        {
            DataTable dataTable = new DataTable();

            //what if it is empty???
            dataTable = _userDAO.FindByEmail(email);

            var user = new User();

            foreach (DataRow dr in dataTable.Rows)
            {
                userVO.idUser = Int32.Parse(dr["t01_id"].ToString());
                userVO.firstname = dr["t01_firstname"].ToString();
                userVO.lastname = dr["t01_lastname"].ToString();
                userVO.email = dr["t01_email"].ToString();
            }
            return user;
        }
    }
}


/// <method>
/// Get User Email By Firstname or Lastname and return VO
/// </method>
public UserVO getUserEmailByName(string name)
{
    UserVO userVO = new UserVO();
    DataTable dataTable = new DataTable();

    dataTable = _userDAO.searchByName(name);

    foreach (DataRow dr in dataTable.Rows)
    {
        userVO.idUser = Int32.Parse(dr["t01_id"].ToString());
        userVO.firstname = dr["t01_firstname"].ToString();
        userVO.lastname = dr["t01_lastname"].ToString();
        userVO.email = dr["t01_email"].ToString();
    }
    return userVO;
}

/// <method>
/// Get User Email By Id and return DataTable
/// </method>
public UserVO getUserById(string _id)
{
    UserVO userVO = new UserVO();
    DataTable dataTable = new DataTable();
    dataTable = _userDAO.searchById(_id);

    foreach (DataRow dr in dataTable.Rows)
    {
        userVO.idUser = Int32.Parse(dr["t01_id"].ToString());
        userVO.firstname = dr["t01_firstname"].ToString();
        userVO.lastname = dr["t01_lastname"].ToString();
        userVO.email = dr["t01_email"].ToString();
    }
    return userVO;
}
    }