Test-Setup:
=============

	Gegeben sind 100 Event-Klasse (Event1, Event2, ....) sowie verschiedene Klasse mit dem Namen HandleEvents* die jeweils 100 Handle-Methode für jedes einzelne Event haben
	
	Jede HandleEvents*-Klasse bildet einen oder mehrere Aufrufvarianten ab
	
Die Tests:
=============

## HandlesDynamic ##
	
	Aufruf mit dynmaic-Cast
	
## HandlesCaseWhen ##
	
	Vergleichsmessung mit einer SwitchCase-Fallunterscheidung
		
## HandleEventsReflection ##
		
	Die jeweiligen Methodinfo's werden ermittelt und gecached.
	
## HandleEventsReflectionDelegate ##
	
	Aufruf über eine per Dynamic-Expression erzeugtes Delegate welches gecached wird.
		
## HandleEventsReflectionFastInvoke ##
	
	Aufruf über DynamicMethod und der Emit-API.
	
## HandleEventsReflectionCodeDom ##
	
	Dynamisches erzeugen von C#-Code (Switch-Case-Block) und Invoke über Reflection
		
## HandleEventsReflectionT4 ##
	
	Switch-Case Codegenerierung per T4-Template
	
Ergebnis für 1.000.000 Events:
=============

* Result for 'HandlesDynamic': 4549ms
* Result for 'HandlesDynamic': 3984ms
* Result for 'HandlesCaseWhen': 78ms
* Result for 'HandlesCaseWhen': 76ms
* Result for 'HandleEventsReflection': 299ms
* Result for 'HandleEventsReflection': 288ms
* Result for 'HandleEventsReflectionDelegate': 1351ms
* Result for 'HandleEventsReflectionDelegate': 1315ms
* Result for 'HandleEventsReflectionCodeDom': 551ms
* Result for 'HandleEventsReflectionCodeDom': 331ms
* Result for 'HandleEventsReflectionFastInvoke': 1366ms
* Result for 'HandleEventsReflectionFastInvoke': 1369ms
* Result for 'HandleEventsReflectionT4': 77ms
* Result for 'HandleEventsReflectionT4': 76ms

Skallierung der Laufzeit als Diagramm:
=============
![picture alt](http://imagizer.imageshack.com/img910/6154/jT3pmV.png "Skallierung")

