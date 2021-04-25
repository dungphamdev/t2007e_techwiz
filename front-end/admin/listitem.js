$(function () {
    data = {};
    fetch('http://localhost:4000/api/item/list', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => response.json())
        .then(res => {
			console.log(res)
			var list = res.list;
			let table = "";
		    table += `<table class="table table-hover table-striped table-bordered table-list">`;
			table += `
				<thead>
					<tr>
						<th scope="col">Item ID</th>
						<th scope="col">Name</th>
						<th scope="col">Restaurant</th>
						<th scope="col">Description</th>
						<th scope="col">Price</th>
						<th scope="col">Image</th>
                        <th scope="col">Active</th>
						<th scope="col">Option</th>
					</tr>
				</thead>`;
			table += `<tbody>`;
            for(var i = 0; i < list.length; i++)
            {
                table += `
				 <tr>	   
				   <td>${list[i].itemId || ''}</td>
				   <td>${list[i].itemName || ''}</td>
				   <td>${list[i].restaurantId || ''}</td>
				   <td>${list[i].itemDescription || ''}</td>
				   <td>$${list[i].itemPrice || '0'}</td>	
				   <td><img src=${list[i].imageSrc} alt=${list[i].imageName}" width="50" height="60"></td>			
                   <td>${list[i].active || 'false'}</td>	
				   <td><button onclick='updateItem(${list[i].itemId || ''})'>Update</button></td>
                </tr>`;
            }
            table += `</tbody>`;
            $('#resultitem').html(table);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
});


// $(document).ready(function(){
// 	$.ajax({
// 		method: "POST",
// 		url: 'http://localhost:4000/api/item/list',
// 		data: null,
// 		success: function (result) {
// 			var rs = JSON.stringify(result);
// 			var list = rs.list;
//             console.log(list);
//             let table = "";
// 		    table += `<table class="table table-hover table-striped table-bordered table-list">`;
// 			table += `
// 				<thead>
// 					<tr>
// 						<th scope="col">Item ID</th>
// 						<th scope="col">Name</th>
// 						<th scope="col">Restaurant</th>
// 						<th scope="col">Description</th>
// 						<th scope="col">Price</th>
// 						<th scope="col">Path Image</th>
//                         <th scope="col">Active</th>
// 						<th scope="col">Option</th>
// 					</tr>
// 				</thead>`;
// 			table += `<tbody>`;
//             for(var i = 0; i < list.length; i++)
//             {
//                 table += `
// 				 <tr>	   
// 				   <td>${list[i].itemId || ''}</td>
// 				   <td>${list[i].itemName || ''}</td>
// 				   <td>${list[i].restaurantId || ''}</td>
// 				   <td>${list[i].itemDescription || ''}</td>
// 				   <td>$${list[i].itemPrice || '0'}</td>	
// 				   <td>${list[i].mainImagePath || ''}</td>			
//                    <td>${list[i].active || 'false'}</td>	
// 				   <td><button onclick='updateItem(${list[i].itemId || ''})'>Update</button></td>
//                 </tr>`;
//             }
//             table += `</tbody>`;
//             $('#resultitem').html(table);
//         },    	
//     });	
// })

// function convertStatus(id)
// {
//     switch(Number.parseInt(id))
//     {
//         case -1 : return 'Cancel';
            
//         case 1 : return 'Create';
//             break;
//         case 2 : return 'Confirm';
//             break;
//         default : '';     
//     }
// }

function updateItem(itemID)
{
	alert(itemID);
}