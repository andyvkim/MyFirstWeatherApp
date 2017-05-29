(function () {
    'use strict';

    angular
        .module('WeatherApp')
        .controller('WeatherCtrl', WeatherCtrl);

    WeatherCtrl.$inject = ['$location','$scope']; 

    function WeatherCtrl($location, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'WeatherCtrl';

        vm.RequestData = {};
        vm.ViewWeatherData = {};

        vm.submitData = submit;

        activate();

        function submit() {
            debugger;
            if (vm.RequestData.lattitude && vm.RequestData.longitude) {
                $.ajax({
                    type: "POST",
                    url: "Home/GetForecast",
                    data: JSON.stringify({ longitude: vm.RequestData.longitude, latitude: vm.RequestData.lattitude}),
                    contentType: "application/json; charset=utf-8"
                })
                    .done(function(data) {
                        vm.ViewWeatherData = JSON.parse(data);
                        vm.SubmitClicked = true;
                    });
            }
        }

        function activate() {
           
        }
    }
})();
