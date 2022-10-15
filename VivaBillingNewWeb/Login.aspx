<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VivaBillingNewWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CSS/bootstrap.min.css" />
    <script src="JS/jquery.min.js"></script>
    <script src="JS/bootstrap.min.js"></script>
    <title></title>
    <style>
        *{
            outline:none;
        }
        /* Bordered form */
        form {
            border: 3px solid #f1f1f1;
        }

        /* Full-width inputs */
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
            border-radius:10px;

        }

        /* Set a style for all buttons */
        input[type=submit] {
            /*background-color: #4CAF50;*/
            background-color: dodgerblue;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
            border-radius:10px;
        }

            /* Add a hover effect for buttons */
            button:hover {
                opacity: 0.8;
            }

        /* Extra style for the cancel button (red) */
        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        /* Center the avatar image inside this container */
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        /* Avatar image */
        .avatar {
            width: 50%;
            border-radius: 10px;
        }

        /* Add padding to containers */
        .container {
            padding: 16px;
        }

        /* The "Forgot password" text */
        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cancelbtn {
                width: 100%;
            }
        }
        #form1
        {
            width:50%;
            margin:auto;
            border-radius:20px;
            padding:30px;
        }
    </style>
</head>
<body>
    <div style="display: table;height:100vh;width:100%;">
        <div style="display: table-cell;vertical-align:middle;">
            <form id="form1" runat="server">
                <div class="imgcontainer">
                    <img src="03.jpg" alt="Avatar" class="avatar">
                </div>

                <div class="container">
                    <label for="uname"><b>Username</b></label>
                    <input type="text" runat="server" id="username" placeholder="Enter Username" name="uname" >

                    <label for="psw"><b>Password</b></label>
                    <input type="password" runat="server" id="password"  placeholder="Enter Password" name="psw" >

                    <asp:Button runat="server" ID="BtnLogin" Text="Login" OnClick="BtnLogin_Click" />
                    <div runat="server" id="ServerMessage"></div>
                </div>

             
            </form>
        </div>
    </div>
</body>
</html>
