(function () {
    'use strict';

    angular.module('app').factory('mathsService', mathsService);

    mathsService.$inject = ["$http"];


    function mathsService($http) {
        var dataService = $http;

        return {
            getQuestionSet: function(id) {
                return dataService.get("api/maths/" + id)
                    .then(function(result) {
                        return result.data;
                    });
            },
            scoreQuestionSet: function(questionSet) {
                return dataService.put("api/maths/", questionSet)
                    .then(function (result) {
                        return result.data;
                    });
            }
        };
    }
})();