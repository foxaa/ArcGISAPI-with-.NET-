app.controller("RouteController", function ($scope, $http,$window) {
    require([
              "esri/geometry/Point",
              "esri/Map",
              "esri/views/MapView",
              "esri/Graphic",
              "esri/layers/GraphicsLayer",
              "esri/tasks/RouteTask",
              "esri/tasks/support/RouteParameters",
              "esri/tasks/support/FeatureSet",
              "esri/core/urlUtils",
              "dojo/on",
              "dojo/domReady!"
        ], function (
              Point,Map, MapView, Graphic, GraphicsLayer, RouteTask, RouteParameters,
              FeatureSet, urlUtils, on
            ) {
            // Proxy the route requests to avoid prompt for log in
            /* urlUtils.addProxyRule({
                 urlPrefix: "route.arcgis.com",
                 proxyUrl: "/sproxy/"
             });*/

            // Point the URL to a valid route service
            var routeTask = new RouteTask({
                url: "https://route.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World"
            });

            // The stops and route result will be stored in this layer
            var routeLyr = new GraphicsLayer();

            // Setup the route parameters
            var routeParams = new RouteParameters({
                stops: new FeatureSet(),
                outSpatialReference: { // autocasts as new SpatialReference()
                    wkid: 3857
                }
            });

            // Define the symbology used to display the stops
            var stopSymbol = {
                type: "simple-marker", // autocasts as new SimpleMarkerSymbol()
                style: "cross",
                size: 15,
                outline: { // autocasts as new SimpleLineSymbol()
                    width: 4
                }
            };

            // Define the symbology used to display the route
            var routeSymbol = {
                type: "simple-line", // autocasts as SimpleLineSymbol()
                color: [0, 0, 255, 0.5],
                width: 5
            };

            var map = new Map({
                basemap: "streets",
                layers: [routeLyr] // Add the route layer to the map
            });
            var view = new MapView({
                container: "viewDiv", // Reference to the scene div created in step 5
                map: map, // Reference to the map object created before the scene
                center: [-117.195, 34.057],
                zoom: 14
            });
            getRoutes();

            view.on("click", function (event) {
                event.stopPropagation(); // overwrite default click-for-popup behavior

                // Get the coordinates of the click on the view
                var lat = event.mapPoint.latitude
                var lon = event.mapPoint.longitude;
                console.log(lat +','+ lon);
            });
            // Adds a graphic when the user clicks the map. If 2 or more points exist, route is solved.
            on(view, "click", addStop);

            function addStop(event) {
                // Add a point at the location of the map click
                var stop = new Graphic({
                    geometry: event.mapPoint,
                    symbol: stopSymbol
                });
                console.log(stop);
                routeLyr.add(stop);
                // Execute the route task if 2 or more stops are input
                routeParams.stops.features.push(stop);
                if (routeParams.stops.features.length == 2) {
                    routeTask.solve(routeParams).then(showRoute);
                }else if(routeParams.stops.features.length>2)
                {
                    routeLyr.removeAll();
                    routeParams.stops.features.length = 0;
                }
            }
            // Adds the solved route to the map as a graphic
            function showRoute(data) {
                var routeResult = data.routeResults[0].route;
                routeResult.symbol = routeSymbol;
                routeLyr.add(routeResult);
            }
             function getRoutes () {
                $scope.selectedRoute = null;
                $http.get('/api/Route/GetRoutes').then(function (response) {
                    $scope.routes = response.data;
                    $window.alert("Get routes");
                }, function (response) {
                    $window.alert("Error: " + response.data.Message);
                });
            }

             $scope.getRoute = function (id) {
                 routeLyr.removeAll();
                 routeParams.stops.features.length = 0;
                $http.get("api/Route/GetSingleRoute?id=" + id)
                    .then(function (response) {
                        var id = response.data.id;
                        var name = response.data.name;
                        var pointA_x = response.data.pointA_x;
                        var pointA_y = response.data.pointA_y;
                        var pointB_x = response.data.pointB_x;
                        var pointB_y = response.data.pointB_y;
                        $window.alert(pointA_x);
                        var pointA = new Point(pointA_x, pointA_y);
                        var stop = new Graphic({
                            geometry:pointA,
                            symbol:stopSymbol
                        });
                        routeLyr.add(stop);
                        routeParams.stops.features.push(stop);
                        var pointB = new Point(pointB_x, pointB_y);
                        var stop2 = new Graphic({
                            geometry: pointB,
                            symbol: stopSymbol
                        });
                        routeLyr.add(stop2);
                        $window.alert(stop);
                        //console.log(stop);
                        $window.alert(stop2);
                        //console.log(stop2);
                        routeParams.stops.features.push(stop2);
                        routeTask.solve(routeParams).then(showRoute);
                    })
             }
             $scope.Add = function () {
                 if ($scope.name == undefined) {
                     $window.alert("Please enter route name.");
                 } else {
                     var routeData = {
                         name: $scope.name,
                         pointA_x: routeParams.stops.features["0"].geometry.longitude,
                         pointA_y: routeParams.stops.features["0"].geometry.latitude,
                         pointB_x: routeParams.stops.features["1"].geometry.longitude,
                         pointB_y: routeParams.stops.features["1"].geometry.latitude,
                     };
                     $http.post("api/Route/AddRoute", routeData)
                         .then(function (response) {
                             $window.alert("Route added successful.");
                             getRoutes();
                         }, function (response) {
                             $window.alert("Error: " + response.error);
                         });
                 }
             }

        });
        /*$scope.getRoutes = function () {
            $scope.selectedRoute = null;
            $http.get('/api/Route/GetRoutes').then(function (response) {
                $scope.routes = response.data;
                $window.alert("doso");
            }, function (response) {
                $window.alert("Error: " + response.data.Message);
            });
        }

        $scope.getRoute = function (id) {
            $http.get("api/Route/GetSingleRoute?id=" + id)
                .then(function (response) {
                    $scope.id = response.data.id;
                    $scope.name = response.data.name;
                    $scope.pointA_x = response.data.pointA_x;
                    $scope.pointA_y = response.data.pointA_y;
                    $scope.pointB_x = response.data.pointB_x;
                    $scope.pointB_y = response.data.pointB_y;
                    $window.alert("pozvan get route");
                })
        }*/
});