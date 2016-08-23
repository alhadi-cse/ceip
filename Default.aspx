<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .carousel {
            margin: 0px auto;
        }
         .carousel-inner > .item > img,
         .carousel-inner > .item > a > img {
             width: 100%;
             height: 430px;
             margin: auto;
         }

        p.drop-caps.colored:first-child::first-letter {
            color: #0088cc;
        }

        p.drop-caps:first-child::first-letter {
            color: #171717;
            float: left;
            font-family: Georgia;
            font-size: 50px;
            line-height: 50px;
            margin-right: 5px;
            margin-top: 5px;
            padding: 4px;
        }
    </style>

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
            <li data-target="#myCarousel" data-slide-to="3"></li>
             <li data-target="#myCarousel" data-slide-to="4"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="images/slide/img-1.jpg" alt="......">
            </div>

            <div class="item">
                <img src="images/slide/img-2.jpg" alt="......">
            </div>

            <div class="item">
                <img src="images/slide/img-3.jpg" alt=".....">
            </div>

            <div class="item">
                <img src="images/slide/img-4.jpg" alt=".....">
            </div>
             <div class="item">
                <img src="images/slide/img-5.jpg" alt=".....">
            </div>
        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <div style="width: 95%; margin-left: auto !important; margin-right: auto !important; margin-top: 25px">
        <div class="col-md-10 text-justify" style="width: 100% !important;">
            <p class="drop-caps colored">
                CEIP-1 is the investment is to rehabilitate polder embankments and strengthen their long-term durability through heightened embankment, improved drainage, and foreshore afforestation. The project aims at restoration of the agriculture sector within the polder areas and rehabilitation of infrastructure with “build back better” designs that can guard against both tidal flooding and frequent storm surges. The project will pilot the mobilization of Water Management Organizations (WMOs) to provide coordination among the competing needs of various users and to ensure sustainability by assigning maintenance responsibility to the WMO. The project will also provide long term monitoring of the coastal zone, technical assistance, and strategic studies and training to strengthen the role of the polder infrastructure in protection of human lives, physical assets, the environment and agricultural productivity. Most importantly it will support the initial implementation of the first slice of a fifteen to twenty year program for polder scheme rehabilitation and upgrading. Given Bangladesh’s high level of vulnerability to natural disasters and climate change, and the large population residing in the coastal zone, this project is vital to its development. 
            </p>

        </div>
    </div>
</asp:Content>
