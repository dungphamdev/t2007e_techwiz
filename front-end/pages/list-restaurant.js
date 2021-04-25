$('.Slick').slick({
    dots: true,
    infinite: false,
    speed: 300,
    slidesToShow: 5,
    slidesToScroll: 5,
    responsive: [
        {
            breakpoint: 1024,
            settings: {
                slidesToShow: 4,
                slidesToScroll: 4,
                infinite: true,
                dots: true
            }
        },
        {
            breakpoint: 600,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3,
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 2,
            }
        }
        // You can unslick at a given breakpoint now by adding:
        // settings: "unslick"
        // instead of a settings object
    ]
});

$(function () {
    //get list restaurants;
    data = {};
    fetch('http://localhost:4000/api/restaurant/list', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => response.json())
        .then(res => {
            let listRestaurants = res.list ?? [];
            //generate DOM
            let html = '';
            listRestaurants.forEach(e => {
                html += `<img src=${e.imageSrc} alt=${e.imageName}" width="500" height="600">`
            });
            $("#test-list-restaurant").append(html);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
});