# Production Build Status
[![VSTS Build Status](https://zn1web.visualstudio.com/_apis/public/build/definitions/79e054d5-f75b-4213-afad-e16c92339659/1/badge)](https://zn1web.visualstudio.com/MyFirstProject/_dashboards?activeDashboardId=a6ca41b6-9337-4f81-9f09-4f047d05788b)

## Production website
Produkcyjna wersja strony.
http://ogarnij-agile.azurewebsites.net/

# Pull requests dev -> master builds
[![VSTS Build Status](https://zn1web.visualstudio.com/_apis/public/build/definitions/79e054d5-f75b-4213-afad-e16c92339659/3/badge)](https://zn1web.visualstudio.com/_apis/public/build/definitions/79e054d5-f75b-4213-afad-e16c92339659/3/badge)

## Staging website
Zawiera zmiany z pull requesta na master. Jeśli zachowanie strony będzie poprawne, to admin wciągnie zmiany na produkcję.
http://ogarnij-agile-staging.azurewebsites.net

# Development Build Status
[![VSTS Build Status](https://zn1web.visualstudio.com/_apis/public/build/definitions/79e054d5-f75b-4213-afad-e16c92339659/2/badge)](https://zn1web.visualstudio.com/_apis/public/build/definitions/79e054d5-f75b-4213-afad-e16c92339659/2/badge)

## Development website
Zawiera stan z brancha development.
http://ogarnij-agile-dev.azurewebsites.net/

# Waffle.io work progress
[![Waffle.io - Columns and their card count](https://badge.waffle.io/ZespolNumerJeden/zn1Web.svg?columns=all)](http://waffle.io/ZespolNumerJeden/zn1Web)

# Zasady commitowania - pipeline CI & CD
1. Każdy dev ma swojego brancha (moze miec kilka do różnych feature'ów)
1. Po zbudowaniu na swojej maszynie **WRAZ Z TESTAMI** commituje na swojego brancha
1. Jeśli na lokalnej maszynie build przechodzi to składamy pull request na development, lub bezpośrednio commitujemy na development.
    1. Jeśli złożyliśmy Pull Request (dalej ***PR***):
        1. uruchomi się build naszego ***PR***
        1. sprawdzamy status builda naszego ***PR*** (wchodzimy w szczegóły ***PR*** i szukamy poniższego okienka - klikamy **Show all checks** i widzimy status builda.
        ![Szczegóły pull requesta](https://i.imgur.com/G8mIthD.png)
        1. jeśli status wszystkich checków jest zielony, to możemy sami zaakceptować ***PR*** - przycisk **Merge Pull Request**
    1. Jeśli bezpośrednio commitowaliśmy na development, przechodzimy do następnego kroku.
1. W tym momencie uruchomił się build brancha development. Jeśli będzie pozytywny to zmiany będą widoczne na [wersji developerskiej strony](http://ogarnij-agile-dev.azurewebsites.net)
1. Dokładnie sprawdzamy działanie strony z naszymi zmianami, zwracamy uwagę na inne błędy - jęsli się pojawią to tworzymy issue na tablicy.
1. Jeśli strona działa prawidłowo - składamy pull request na master z development.
1. Tu kończy się działanie deva.

Wkracza dev lead i testerzy.
1. W tym momencie robi się build ***PR*** na mastera
2. Jeśli status jest prawidłowy to dev lead sprawdza kod i akceptuje (lub nie) ***PR***
3. Po zmergowaniu, następuje kolejny build, jeśli jest ok, to zmiany trafiają na [staging website](http://ogarnij-agile-staging.azurewebsites.net)
4. Testerzy robią swoją pracę.
5. Test lead akceptuje zmiany (Visual Studio Team Services)
6. Zmiany trafiają na produkcję.




