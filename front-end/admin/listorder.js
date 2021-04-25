$(document).ready(function(){
    $.ajax({
		method: "POST",
		url: 'http://localhost:4000/api/admin/bills/list',
		data: null,
		success: function (result) {
			var list = result.list;
            console.log(list)
            let table = "";
		    table += `<table class="table table-hover table-striped table-bordered table-list">`;
			table += `
				<thead>
					<tr>
						<th scope="col">OrderId</th>
						<th scope="col">CustomerId</th>
						<th scope="col">RestaurantId</th>
						<th scope="col">BillAmount</th>
						<th scope="col">Date</th>
						<th scope="col">Status</th>
                        <th scope="col">Date</th>
						<th scope="col">Status</th>
                        <th scope="col">Date</th>
						<th scope="col">Status</th>
                        <th scope="col">Option</th>
					</tr>
				</thead>`;
			table += `<tbody>`;
            for(var i = 0; i < list.length; i++)
            {
                table += `
				 <tr>	   
				   <td>${list[i].billAmount || ''}</td>
				   <td>${list[i].customerId || ''}</td>
				   <td>${list[i].date || ''}</td>
				   <td>${list[i].orderDate || ''}</td>
				   <td>${list[i].orderId || ''}</td>	
				   <td>${list[i].orderItemName || ''}</td>			
                   <td>${list[i].orderItemQty || ''}</td>	
                   <td>${list[i].orderLocation || ''}</td>	
                   <td>${list[i].restaurantId || ''}</td>		
                   <td>${convertStatus(list[i].status)}</td>	   
                   <td><button>Approech</button></td>	  
                </tr>`;
            }
            table += `</tbody>`;
            $('#result').html(table);
            console.log(list);
        }    	
    })	
})

function convertStatus(id)
{
    switch(Number.parseInt(id))
    {
        case -1 : return 'Cancel';
            
        case 1 : return 'Create';
            break;
        case 2 : return 'Confirm';
            break;
        default : '';     
    }
}