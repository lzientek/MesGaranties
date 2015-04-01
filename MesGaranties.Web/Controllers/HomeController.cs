// DansTesComs -> DansTesComs.WebSite ->HomeController.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System;
using System.Web.Mvc;
using MesGaranties.Core.Models;

namespace DansTesComs.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly MesGarantiesEntities db = new MesGarantiesEntities();

        public ActionResult Gdb()
        {
            db.Database.ExecuteSqlCommand(

"SET ANSI_NULLS ON\n"+

"SET QUOTED_IDENTIFIER ON\n"+

"CREATE TABLE [dbo].[Tokens](\n"+
"	[Id] [int] NOT NULL,\n"+
"	[Token] [nvarchar](50) NOT NULL,\n"+
"	[CreationDate] [datetime] NOT NULL,\n"+
"	[ExpirationDate] [datetime] NOT NULL,\n"+
"PRIMARY KEY CLUSTERED \n"+
"(\n"+
"	[Id] ASC\n"+
")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\n"+
") ON [PRIMARY]\n"+

"/****** Object:  Table [dbo].[Prenium]    Script Date: 03/21/2015 20:51:11 ******/\n"+
"SET ANSI_NULLS ON\n"+

"SET QUOTED_IDENTIFIER ON\n"+

"CREATE TABLE [dbo].[Prenium](\n"+
"	[Id] [int] IDENTITY(1,1) NOT NULL,\n"+
"	[Prenium] [bit] NOT NULL,\n"+
"	[CreationDate] [datetime] NULL,\n"+
"	[ExpirationDate] [datetime] NULL,\n"+
"	[UserId] [int] NOT NULL,\n"+
"PRIMARY KEY CLUSTERED \n"+
"(\n"+
"	[Id] ASC\n"+
")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\n"+
") ON [PRIMARY]\n"+

"/****** Object:  Table [dbo].[Garantie]    Script Date: 03/21/2015 20:51:11 ******/\n"+
"SET ANSI_NULLS ON\n"+

"SET QUOTED_IDENTIFIER ON\n"+

"CREATE TABLE [dbo].[Garantie](\n"+
"	[Id] [int] IDENTITY(1,1) NOT NULL,\n"+
"	[CreationDate] [datetime] NOT NULL,\n"+
"	[LastModificationDate] [datetime] NOT NULL,\n"+
"	[Name] [nvarchar](200) NOT NULL,\n"+
"	[PhotoProduit] [nvarchar](200) NULL,\n"+
"	[PhotoTicketDeCaisse] [nvarchar](200) NULL,\n"+
"	[PhotoFicherAnnexe] [nvarchar](200) NULL,\n"+
"	[Commentaire] [text] NULL,\n"+
"	[FinDeGarantie] [datetime] NULL,\n"+
"	[UserId] [int] NOT NULL,\n"+
"PRIMARY KEY CLUSTERED \n"+
"(\n"+
"	[Id] ASC\n"+
")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\n"+
") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\n"+



"/****** Object:  ForeignKey [FK_Token_ToUser]    Script Date: 03/21/2015 20:51:11 ******/\n"+
"ALTER TABLE [dbo].[Tokens]  WITH CHECK ADD  CONSTRAINT [FK_Token_ToUser] FOREIGN KEY([Id])\n"+
"REFERENCES [dbo].[Users] ([Id])\n"+

"ALTER TABLE [dbo].[Tokens] CHECK CONSTRAINT [FK_Token_ToUser]\n"+

"/****** Object:  ForeignKey [FK_Prenium_ToUsers]    Script Date: 03/21/2015 20:51:11 ******/\n"+
"ALTER TABLE [dbo].[Prenium]  WITH CHECK ADD  CONSTRAINT [FK_Prenium_ToUsers] FOREIGN KEY([UserId])\n"+
"REFERENCES [dbo].[Users] ([Id])\n"+

"ALTER TABLE [dbo].[Prenium] CHECK CONSTRAINT [FK_Prenium_ToUsers]\n"+

"/****** Object:  ForeignKey [FK_Garantie_ToUsers]    Script Date: 03/21/2015 20:51:11 ******/\n"+
"ALTER TABLE [dbo].[Garantie]  WITH CHECK ADD  CONSTRAINT [FK_Garantie_ToUsers] FOREIGN KEY([UserId])\n"+
"REFERENCES [dbo].[Users] ([Id])\n"+

"ALTER TABLE [dbo].[Garantie] CHECK CONSTRAINT [FK_Garantie_ToUsers]\n"
);
            return new EmptyResult();
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}