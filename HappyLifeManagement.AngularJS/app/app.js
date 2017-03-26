var app = angular.module("myApp", ['ngSanitize', 'ngRoute']);

/* private function */
function routeProviderConfig($routeProvider) {
    $routeProvider.when("/", {
        controller: "noteController",
        templateUrl: "app/note/index.tpl.html"
    });

    $routeProvider.otherwise("/");
}

function noteController($scope, $http) {

    var url = "http://localhost:502/api/notes";

    $http.get(url).success(function (response) {
        $scope.students = [];

        $scope.notes = response;
    });

}


//app.config(["$routeProvider"], routeProviderConfig);

noteController.$inject = ['$scope', '$http'];

app.controller("noteController", noteController);



