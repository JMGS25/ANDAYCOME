using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assembler
{
    public class CommentAssembler
    {
        public CommentViewModel ConvertENToModelUI(ComentariosEN en)
        {
            CommentViewModel com = new CommentViewModel();

            com.Id = en.Id;
            com.Client = en.Client.Name;
            com.Photo = en.Client.Photo;
            com.Date = en.Date;
            com.Content = en.Content;
                       
            return com;
        }

        public IList<CommentViewModel> ConvertListENToModel(IList<ComentariosEN> comments)
        {
            IList<CommentViewModel> comv = new List<CommentViewModel>();
            foreach (ComentariosEN com in comments)
            {
                comv.Add(ConvertENToModelUI(com));
            }
            return comv;
        }
    }
}