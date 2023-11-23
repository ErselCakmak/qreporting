$(function(e) {



    //______Data-Table
    $('#data-table').DataTable({
        "order": [
            [0, "desc"]
        ],
        order: [],
        columnDefs: [{ orderable: false, targets: [0, 4, 5] }],
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        }
    });

    //______Select2
    $('.select2').select2({
        minimumResultsForSearch: Infinity
    });



    $('#world-map-markers1').vectorMap({
        map: 'world_mill_en',
        scaleColors: ['#6c5ffc', '#e82646', '#05c3fb'],

        normalizeFunction: 'polynomial',

        hoverOpacity: 0.7,

        hoverColor: false,

        regionStyle: {

            initial: {

                fill: '#edf0f5'
            }
        },
        markerStyle: {
            initial: {
                r: 6,
                'fill': '#6c5ffc',
                'fill-opacity': 0.9,
                'stroke': '#fff',
                'stroke-width': 9,
                'stroke-opacity': 0.2
            },

            hover: {
                'stroke': '#fff',
                'fill-opacity': 1,
                'stroke-width': 1.5
            }
        },
        backgroundColor: 'transparent',
        markers: [{
            latLng: [40.3, -101.38],
            name: 'USA',
        }, {
            latLng: [22.5, 1.51],
            name: 'India'
        }, {
            latLng: [50.02, 80.55],
            name: 'Bahrain'
        }, {
            latLng: [3.2, 73.22],
            name: 'Maldives'
        }, {
            latLng: [35.88, 14.5],
            name: 'Malta'
        }, ]
    });

});

function getCssValuePrefix() {
    var retuenValue = ''; //default to standard syntax
    var prefixes = ['-o-', '-ms-', '-moz-', '-webkit-'];

    // Create a temporary DOM object for testing
    var dom = document.createElement('div');

    for (var i = 0; i < prefixes.length; i++) {
        // Attempt to set the style
        dom.style.background = prefixes[i] + 'linear-gradient(#ffffff, #000000)';

        // Detect if the style was successfully set
        if (dom.style.background) {
            retuenValue = prefixes[i];
        }
    }

    dom = null;
    delete dom;

    return retuenValue;
}

function index() {

    /*-----Transactions-----*/
    var myCanvas = document.getElementById("transactions");
    myCanvas.height = "330";

    var myCanvasContext = myCanvas.getContext("2d");
    var gradientStroke1 = myCanvasContext.createLinearGradient(0, 80, 0, 280);
    gradientStroke1.addColorStop(0, hexToRgba(myVarVal, 0.8) || 'rgba(108, 95, 252, 0.8)');
    gradientStroke1.addColorStop(1, hexToRgba(myVarVal, 0.2) || 'rgba(108, 95, 252, 0.2) ');

    var gradientStroke2 = myCanvasContext.createLinearGradient(0, 80, 0, 280);
    gradientStroke2.addColorStop(0, hexToRgba(myVarVal1, 0.8) || 'rgba(5, 195, 251, 0.8)');
    gradientStroke2.addColorStop(1, hexToRgba(myVarVal1, 0.8) || 'rgba(5, 195, 251, 0.2) ');
    document.getElementById('transactions').innerHTML = ''; 
    var myChart = new Chart(myCanvas, {

        type: 'line',
        data: {
            labels: ["Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec"],
            type: 'line',
            datasets: [{
                label: 'Total Sales',
                data: [100, 210, 180, 454, 454, 230, 230, 656, 656, 350, 350, 210],
                backgroundColor: gradientStroke1,
                borderColor: myVarVal,
                pointBackgroundColor: '#fff',
                pointHoverBackgroundColor: gradientStroke1,
                pointBorderColor: myVarVal,
                pointHoverBorderColor: gradientStroke1,
                pointBorderWidth: 0,
                pointRadius: 0,
                pointHoverRadius: 0,
                borderWidth: 3,
                fill: 'origin'
            }, {
                label: 'Total Orders',
                data: [200, 530, 110, 110, 480, 520, 780, 435, 475, 738, 454, 454],
                backgroundColor: 'transparent',
                borderColor: '#05c3fb',
                pointBackgroundColor: '#fff',
                pointHoverBackgroundColor: gradientStroke2,
                pointBorderColor: '#05c3fb',
                pointHoverBorderColor: gradientStroke2,
                pointBorderWidth: 0,
                pointRadius: 0,
                pointHoverRadius: 0,
                borderWidth: 3,
                fill: 'origin',

            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            tooltips: {
                enabled: false,
            },
            legend: {
                display: false,
                labels: {
                    usePointStyle: false,
                },
            },
            scales: {
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false,
                        drawBorder: false,
                        color: 'rgba(119, 119, 142, 0.08)'
                    },
                    ticks: {
                        fontColor: '#b0bac9',
                        autoSkip: true,
                    },
                    scaleLabel: {
                        display: false,
                        labelString: 'Month',
                        fontColor: 'transparent'
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: 1050,
                        stepSize: 150,
                        fontColor: "#b0bac9",
                    },
                    display: true,
                    gridLines: {
                        display: true,
                        drawBorder: false,
                        zeroLineColor: 'rgba(142, 156, 173,0.1)',
                        color: "rgba(142, 156, 173,0.1)",
                    },
                    scaleLabel: {
                        display: false,
                        labelString: 'sales',
                        fontColor: 'transparent'
                    }
                }]
            },
            title: {
                display: false,
                text: 'Normal Legend'
            }
        }
    });
}