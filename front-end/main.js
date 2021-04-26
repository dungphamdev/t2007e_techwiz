$(".responsive-carousel").slick({
  // infinite: false,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 1,
  prevArrow: '.prev-arrow',
  nextArrow: '.next-arrow',
  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 3,
        infinite: true,
        dots: true,
      },
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2,
      },
    },
    {
      breakpoint: 480,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
      },
    },
    // You can unslick at a given breakpoint now by adding:
    // settings: "unslick"
    // instead of a settings object
  ],
});

$(document).ready(function(){
    var customer = localStorage.getItem('customer');
    var currentItems = [];
    function loadCart()
    {
      if(customer == null)
      {
        alert('Please Login!');
      }
      else
      {
        currentItems = localStorage.getItem('currentItems');
      }
    }

    function customerNewitem(itemID)
    {
      $(function () {
        data = itemID;
        fetch('http://localhost:4000/api/item/iteminfo', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(res => {
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
    }
})

