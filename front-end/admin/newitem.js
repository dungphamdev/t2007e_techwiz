
$(document).ready(function(){
    fetch("http://localhost:4000/api/restaurant/list", {
        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        data: null,       
    })
    .then(response => response.json())
    .then(res => {
        
        let response = {...res};
        if (response.statusCode === 200) {
            var html = '';
            for(let i = 0;i<response.list.length; i++)
            {
                html += '<option value="' + response.list[i].restaurantId + '">' + response.list[i].restaurantName + '</option>';
            }
            $('#sltRestaurant').html(html);
        } else {
            alert('Fail');
        }
    })
    .catch((error) => {
        console.error('Error:', error);
    });
	
})
function create(){
    let ItemModel = {
		'ItemName': '',
		'RestaurantId': '',
		'ItemDescription': '',
        'ItemPrice': '',
		'ItemCategoryId': '',
		'MainImagePath': '',
    }
    const formData = new FormData(document.getElementById('newitem-form'))
    for (var pair of formData.entries()) {
        if (pair[0] == 'itemname') ItemModel.ItemName = pair[1];
        if (pair[0] == 'sltRestaurant')
        {
            ItemModel.RestaurantId =  pair[1] ? Number(pair[1]) : null ;
        }
		if (pair[0] == 'desc') ItemModel.ItemDescription = pair[1];
		if (pair[0] == 'price')
        {
            ItemModel.ItemPrice =  pair[1] ? Number(pair[1]) : null ;
        }
        if (pair[0] == 'categoryid')
        {
            ItemModel.ItemCategoryId =  pair[1] ? Number(pair[1]) : null ;
        }
		if (pair[0] == 'imagepath') ItemModel.MainImagePath = pair[1];
    }

    console.log('ItemModel:', ItemModel)

    data = {...ItemModel}
    fetch("http://localhost:4000/api/item/create", {
        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
    .then(response => response.json())
    .then(res => {
        console.log('Success:', res);
       let response = {...res};
       if (response.statusCode === 200) {
           //add authen to store
           //localStorage.setItem('customer', JSON.stringify(response.customer));
           alert('Ok');
       } else {
           //remove authen in localstore
           //localStorage.removeItem('customer');
           alert('Fail');
       }
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}