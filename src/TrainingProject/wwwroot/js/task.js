$(document).ready(function () {
    var planets = [{ name: "Saturn", satellites: 17 }, { name: "Jupiter", satellites: 16 }, { name: "Uranus", satellites: 14 }, { name: "Mars", satellites: 2 }, { name: "Neptune", satellites: 2 }, { name: "Earth", satellites: 1 }, { name: "Pluto", satellites: 1 }];

    $("#task1").on("click", function () {

        cleanList();

        var conditionText = $(".task_text").val();

        if (conditionText === NaN || conditionText === "") return null;

        var task1List = $("#task_result_place");

        for (var i = 0; i < planets.length; i++) {

            if (Number(conditionText) < planets[i].satellites) {

                var column = $('<li class="list-group-item"><span class="label label-default label-pill pull-xs-right">' + planets[i].satellites + '</span>' + planets[i].name + '</li>');

                task1List.append(column);
            }
        }
        return null;
    });

    $("#task2").on("click", function () {
        cleanList();

        var conditionText = $(".task_text").val().split(" ");
        var numArray = [];
        var i;
        for (i = 0; i < conditionText.length; i++) {

            if (conditionText[i] !== NaN && conditionText[i] !== "")
                numArray.push(Number(conditionText[i]));
        }

        var result = [];
        var task1List = $("#task_result_place");

        result.push(findMaxMin());
        result.push(sumOfOddEven());
        result.push(compact().slice());
        result.push(sortArray().slice());

        for (i = 0; i < result.length; i++) {
            var column = $('<li class="list-group-item">' + result[i] + "</li>");

            task1List.append(column);
        }

        function findMaxMin() {
            var max = Math.max.apply(null, numArray);
            var min = Math.min.apply(null, numArray);

            return "<p>Max element: " + max.toString() + " with index: " + numArray.indexOf(max) + "</p><p>Min element: " + min.toString() + ' with index: ' + numArray.indexOf(min) + '</p>';
        };

        function sumOfOddEven() {
            var evenSum = 0, oddSum = 0;
            for (i = 0; i < numArray.length; i++) {
                if (i % 2 === 0) oddSum += numArray[i];
                else evenSum += numArray[i];
            }
            return "<p>Sum of even is: " + evenSum + "</p><p>Sum of odd is: " + oddSum + "</p>";
        };

        function compact() {
            for (i = 0; i < numArray.length; i++) {
                if (Math.abs(Number(numArray[i])) < 1) numArray.splice(i, 1);
            }

            return "New array: " + numArray.toString();
        };

        function sortArray() {
            var result = numArray.sort(compareNumeric);

            return '<p>Sort ascending: ' + result.join(', ') + '</p><p>Sort descending: ' + result.reverse().join(', ') + '</p>';
        };

        function compareNumeric(a, b) {
            return a - b;
        }
    });


    $('#task3').on('click', function () {
        cleanList();

        var conditionText = $('.task_text').val();
        var task1List = $('#task_result_place');

        var wordsWithCaps = [];
        var longestWord = "", longestWordIndex = 0;

        var wordsArray = conditionText.match(/([A-Za-z_.-])+\w+/gi);

        for (var i = 0; i < wordsArray.length; i++) {
            if (wordsArray[i].length > longestWord.length) {
                longestWord = wordsArray[i];
                longestWordIndex = i;
            }

            if (wordsArray[i].toLowerCase() !== wordsArray[i])
                wordsWithCaps.push(wordsArray[i]);
        }
        var column = $('<li class="list-group-item"><span class="label label-default label-pill pull-xs-right">' + wordsArray.length + '</span><p>Words count</p></li><li class="list-group-item"><p>Longest word: ' + longestWord + ', index: ' + longestWordIndex +
               '</p></li><li class="list-group-item"><p>Words with capital letter(s): ' + wordsWithCaps.toString() + '</p></li>');

        task1List.append(column);
    });

    function cleanList() {
        var task1ListItems = $("#task_result_place li");
        task1ListItems.remove();
    }

    $("#task4").on("click", function () {
        var a1 = $("#A1").val();
        var a2 = $("#A2").val();
        var b1 = $("#B1").val();
        var b2 = $("#B2").val();

        var cosPhi = (a1 * a2 + b1 * b2) / (Math.sqrt(Math.pow(a1, 2) + Math.pow(b1, 2)) * Math.sqrt(Math.pow(a2, 2) + Math.pow(b2, 2)));

        cleanList();

        var task1List = $("#task_result_place");
        var column = $('<li class="list-group-item">Angle in degrees = ' + Math.acos(cosPhi) * 180 / Math.PI + '°</li><li class="list-group-item">Angle in radians = ' + Math.acos(cosPhi) + "</li>");

        task1List.append(column);
    });

    $("#country").change(function () {
        var countryId = $(this).val();
        $.ajax({
            type: "GET",
            url: "GetStates/" + countryId,
            success: function (data) {
                cleanState();
                $("#state").append(data);
            }
        });
        var stateId = $("#state option").val();
        $.ajax({
            type: "GET",
            url: "GetCities/" + stateId,
            success: function (data) {
                cleanCity();
                $("#city").append(data);
            }
        });
    });

    $("#state").change(function () {
        var stateId = $(this).val();
        $.ajax({
            type: "GET",
            url: "GetCities/" + stateId,
            success: function (data) {
                cleanCity();
                $("#city").append(data);
            }
        });
    });

    function cleanState() {
        var stateListItems = $("#state option");
        stateListItems.remove();
    }

    function cleanCity() {
        var cityListItems = $("#city option");
        cityListItems.remove();
    }

    $("#calculate_ajax").on("click", function () {
        $.ajax({
            type: "post",
            url: "Task",
            data: $("form").serialize(),
            success: function (data) {
                $("#result").html(data);
            }
        });
    });

    $("#calculate_post").on("click", function () {
        $.post("Task", $("form").serialize(), function (data) {
            $("#result").html(data);
        });
    });
});