Test-Setup:
=============

	+ Gegeben sind 100 Event-Klasse (Event1, Event2, ....) sowie verschiedene Klasse mit dem Namen HandleEvents* die jeweils 100 Handle-Methode für jedes einzelne Event haben
	+ Jede HandleEvents*-Klasse bildet einen oder mehrere Aufrufvarianten ab
	
Die Tests:
=============

	HandlesDynamic
	-------
	
	Aufruf mit dynmaic-Cast
	
	HandlesCaseWhen
	-------
	
	Vergleichsmessung mit einer SwitchCase-Fallunterscheidung
		
	HandleEventsReflection
	-------
	
	Die jeweiligen Methodinfo's werden ermittelt und gecached.
	
	HandleEventsReflectionDelegate
	-------
	
	Aufruf über eine per Dynamic-Expression erzeugtes Delegate welches gecached wird.
		
	HandleEventsReflectionFastInvoke
	-------
	
	Aufruf über DynamicMethod und der Emit-API.
		
Ergebnis für 1.000.000 Events:
=============

* Result for 'HandlesDynamic': 9891ms
* Result for 'HandlesDynamic': 3834ms

* Result for 'HandlesCaseWhen': 77ms
* Result for 'HandlesCaseWhen': 76ms

* Result for 'HandleEventsReflection': 298ms
* Result for 'HandleEventsReflection': 292ms

* Result for 'HandleEventsReflectionDelegate': 1358ms
* Result for 'HandleEventsReflectionDelegate': 1286ms

* Result for 'HandleEventsReflectionFastInvoke': 1370ms
* Result for 'HandleEventsReflectionFastInvoke': 1327ms

