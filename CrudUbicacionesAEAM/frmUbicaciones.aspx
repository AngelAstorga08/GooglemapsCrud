<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUbicaciones.aspx.cs" Inherits="CrudUbicacionesAEAM.frmUbicaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crud Google Maps</title>
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script type="text/javascript" src='https://maps.google.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyDiLZvNN5oN3LTbWwXAa1Jb-MC_JMn3s-w'></script>
    <script src="js/locationpicker.jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Ubicacion</label>
                        <asp:HiddenField ID="txtID" runat="server" />
                        <asp:Textbox ID="txtUbicacion" CssClass="form-control" runat="server"></asp:Textbox>
                    </div>
                    <div class="form-group">
                        <div id="ModalMapPreview" style="width: 100%; height: 300px;"></div>
                    </div>
                    <div class="form-group">
                        <label for="ExampleInputPassword1">Lat:</label>
                        <asp:TextBox ID="txtLat" Text="27.368242135686017" CssClass="form-control" runat="server"></asp:TextBox>
                        <label for="ExampleInputPassword1">Long:</label>
                        <asp:TextBox ID="txtLong" Text="-109.9327058982172" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar" UseSubmitBehavior="false" OnClick="btnAgregar_Click" />
                        <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-warning" Text="Modificar" UseSubmitBehavior="false" Enabled="false" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" UseSubmitBehavior="false" Enabled="false" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-default" Text="Limpiar" UseSubmitBehavior="false" OnClick="Limpiar_click"/>
                    </div>
                </div>
                <div class="col-md-8">
                    <br />
                    <h1>Ubicaciones</h1>
                    <asp:GridView ID="gvUbicaciones" runat="server" CssClass="table table-responsive" OnSelectedIndexChanged="SeleccionarUbicacion" AutoGenerateColumns="False">
                        <Columns>
                            <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" >
                            <ControlStyle CssClass="btn btn-info" />
                            </asp:CommandField>
                                <asp:BoundField  DataField="ID" HeaderText="ID" />
                                <asp:BoundField  DataField="Ubicacion" HeaderText="Ubicacion" />
                                <asp:BoundField  DataField="Latitud" HeaderText="Latitud" />
                                <asp:BoundField  DataField="Longitud" HeaderText="Longitud">
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>   
        <script>
            $('#ModalMapPreview').locationpicker({      
            radius: 0,
            location: {
                latitude: parseFloat($('#<%=txtLat.ClientID%>').val()),
                longitude: parseFloat($('#<%=txtLong.ClientID%>').val())
            },
            enableAutocomplete: true,
            inputBinding: {
              latitudeInput: $('#<%=txtLat.ClientID%>'),
              longitudeInput: $('#<%=txtLong.ClientID%>'),
              locationNameInput: $('#<%=txtUbicacion.ClientID%>')
            }
        });
        </script>
    </form>
</body>
</html>
