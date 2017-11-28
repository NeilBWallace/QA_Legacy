<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="jQueryAutocomplete._default" MasterPageFile="Site.master" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

      <form runat="server">
        
     <div>      
     <div style="margin:10px">
          <label class="l " for="firstName"></label>
        <asp:TextBox class="searchbox l" ID="txtCountry" placeholder="Name/ID" runat="server"></asp:TextBox>
        <asp:button ID="search_btn" runat="server" onClick="test" class="searchbox" Text="Search" />
        </div>
      </div>
    
     <fieldset style="margin:10px;">
         
         <legend> Patient Demographics</legend>
         <div>
              
         <label class="l b" for="firstName">Patient Name:</label>
         <asp:TextBox class="l l1" ID="PatName" ReadOnly="true" runat="server"  />
         <label class="l b " for="patient_code">Id:</label>
         <asp:TextBox ReadOnly="true" class="l l1" ID="PersCode" runat="server"/>
         </div>

          <div>
         <label class="l b" for="gender">Gender:</label>
         <asp:TextBox ReadOnly="true" class="l l1" ID="gender" runat="server"/>
       <label class="l b" for="ni_no">NI no:</label>
           <asp:TextBox ReadOnly="true" class="l l1" ID="ni_no" runat="server"/>
 
         </div>
       
        <div>
           <label class="l b" for="d_o_b">Date of Birth:</label>
           <asp:TextBox ReadOnly="true" class="l l1" ID="d_o_b" runat="server"/>
               <label class="l b" for="d_o_d">Date of Death:</label>
           <asp:TextBox ReadOnly="true" class="l l1" ID="d_o_d" runat="server"/>
        </div>
          <div>
           <label class="l b" for="person_type">Person_Type:</label>
           <asp:TextBox ReadOnly="true" class="l l1 " ID="person_type" runat="server"/>
        </div>
         </fieldset>
          <fieldset style="margin:10px;">
         <legend> Address</legend>
         <div>
           <label class="l b" for="name">Premise:</label>
           <asp:TextBox ReadOnly="true" class="l l1 " ID="name" runat="server"/>
           <label class="l b" for="street">Street:</label>
           <asp:TextBox ReadOnly="true" class="l l1" ID="street" runat="server"/>
  
        </div>    
          <div>
           <label class="l b " for="town">Town:</label>
           <asp:TextBox ReadOnly="true" class="l l1" ID="town" runat="server"/>
        <label class="l b" for="postcode">Postcode:</label>
           <asp:TextBox ReadOnly="true" class="l l1" ID="postcode" runat="server"/>
 
        </div>
        <div>
           <label class="l b" for="telephone">Telephone:</label>
           <asp:TextBox ReadOnly="true" class="l l1" ID="telephone" runat="server"/>
        </div>
        

           </fieldset>
             </form>

        





     

    <!-- 
        <table id="tblCustomers" class="tblCustomers" >            
            <thead>
                <tr>
                    <th align="left" class="customerth">ID</th>    
                    <th align="left" class="customerth">Name</th>    
                    <th align="left" class="customerth">DoB</th>    
                    <th align="left" class="customerth">Ni No</th> 
                    <th align="left" class="customerth">DoD</th>
                    <th align="left" class="customerth">Phone</th>  
                </tr>
            </thead> 
            <tbody>
            
            </tbody> 
        </table>  
    -->
          
   
</asp:Content> 
