'use strict';

angular.module('myApp')
.factory('NoteService', ['$http',
    function ($http) {
        var service = {};

        var url = "http://localhost:502/api/notes";

        service.GetNotes = function () {
            return $http.get(url);
        };

        return service;

    }]);