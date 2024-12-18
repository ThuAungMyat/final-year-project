<%@ WebHandler Language="C#" Class="AlbumAndPhotosHandler" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using PTC.BusinessLogic;
using System.IO;

public class AlbumAndPhotosHandler : IHttpHandler
{
    string strcon = ConfigurationManager.ConnectionStrings["PTC2"].ToString();
    public void ProcessRequest(HttpContext context)
    {
        SqlConnection connection = new SqlConnection(strcon);
        connection.Open();
        Stream stream = null;
        //if (context.Request.QueryString["CategoryID"] != null && context.Request.QueryString["CategoryID"] != "")
        //{
        //    string categoryID = context.Request.QueryString["CategoryID"];
        //    SqlCommand command = new SqlCommand("select Image from Categories where CategoryID=" + "'" + categoryID + "'", connection);
        //    SqlDataReader dr = command.ExecuteReader();
        //    dr.Read();
        //    context.Response.BinaryWrite((Byte[])dr[0]);
        //}
        //else if (context.Request.QueryString["AlbumID"] != null && context.Request.QueryString["AlbumID"] != "")
        //{
        //    string albumID = context.Request.QueryString["AlbumID"];
        //    PhotosLogicController photosLogicController = new PhotosLogicController();

        //    stream = photosLogicController.Photos_SelectPhotoByAlbumID(albumID);
        //    const int buffersize = 1024 * 16;
        //    byte[] buffer = new byte[buffersize];
        //    int count = stream.Read(buffer, 0, buffersize);
        //    while (count > 0)
        //    {
        //        context.Response.OutputStream.Write(buffer, 0, count);
        //        count = stream.Read(buffer, 0, buffersize);
        //    }
        //}
        //else if (context.Request.QueryString["PhotoID"] != null && context.Request.QueryString["PhotoID"] != "")
        //{
        //    string photoID = context.Request.QueryString["PhotoID"];
        //    PhotosLogicController photosLogicController = new PhotosLogicController();

        //    stream = photosLogicController.Photos_SelectPhotoByPhotoID(photoID);
            
        //    const int buffersize = 1024 * 16;
        //    byte[] buffer = new byte[buffersize];
        //    int count = stream.Read(buffer, 0, buffersize);
        //    while (count > 0)
        //    {
        //        context.Response.OutputStream.Write(buffer, 0, count);
        //        count = stream.Read(buffer, 0, buffersize);
        //    }
        //}
        //else if (context.Request.QueryString["MovieID"] != null && context.Request.QueryString["MovieID"] != "")
        //{
        //    string photoID = context.Request.QueryString["MovieID"];
        //    MoviesLogicController moviesLogicController = new MoviesLogicController();

        //    stream = moviesLogicController.Movies_SelectMovieImageByMovieID(photoID);

        //    const int buffersize = 1024 * 16;
        //    byte[] buffer = new byte[buffersize];
        //    int count = stream.Read(buffer, 0, buffersize);
        //    while (count > 0)
        //    {
        //        context.Response.OutputStream.Write(buffer, 0, count);
        //        count = stream.Read(buffer, 0, buffersize);
        //    }
        //}
         if (context.Request.QueryString["UserName"] != null && context.Request.QueryString["UserName"] != "")
        {
            string UserName = context.Request.QueryString["UserName"];
            UsersLogicController userLogicController = new UsersLogicController();
            stream = userLogicController.Users_SelectUserImageByUserName(UserName);

            const int buffersize = 1024 * 16;
            byte[] buffer = new byte[buffersize];
            int count = stream.Read(buffer, 0, buffersize);
            while (count > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, count);
                count = stream.Read(buffer, 0, buffersize);
            }
        }
        else if (context.Request.QueryString["UserID"] != null && context.Request.QueryString["UserID"] != "")
        {
            string UserID = context.Request.QueryString["UserID"];
            UsersLogicController userLogicController = new UsersLogicController();
            stream = userLogicController.Users_SelectUserImageByUserID(UserID);

            const int buffersize = 1024 * 16;
            byte[] buffer = new byte[buffersize];
            int count = stream.Read(buffer, 0, buffersize);
            while (count > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, count);
                count = stream.Read(buffer, 0, buffersize);
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}