(function() {
    'use strict';

    angular.module('app', [])
        .controller("mathsController", mathsController);

    mathsController.$inject = ["$scope", "mathsService"];

    function mathsController($scope, mathsService) {
        var vm = this;

        vm.QuestionSet = getQuestionSet("");

        vm.GetOperatorString = getOperatorString;
        vm.GetQuestionState = getQuestionState;
        vm.ScoreQuestionSet = scoreQuestionSet;
        vm.GetQuestionSet = getQuestionSet;

        function getQuestionSet(id) {
            return mathsService.getQuestionSet(id).then(function (response) {
                if (response == null) {
                    vm.QuestionSetNotFound = true;
                    vm.QuestionSet.Questions = null;
                } else {
                    vm.QuestionSetNotFound = false;
                    vm.QuestionSet = response;
                }
                
            });
        }

        function scoreQuestionSet() {
            return mathsService.scoreQuestionSet(vm.QuestionSet).then(function(response) {
                vm.QuestionSet.Questions = response.Questions;
            });
        }

        function getOperatorString(operator) {
            switch (operator) {
            case 1:
                return "*";
            default:
                return "/";
            }
        }

        function getQuestionState(questionState) {
            switch(questionState) {
                case 1:
                    return "";
                case 2:
                    return "Correct!";
                case 3:
                    return "Incorrect!";
                default:
                    return "";
            }
        }

    }
})();