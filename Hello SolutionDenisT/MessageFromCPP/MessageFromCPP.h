// MessageFromCPP.h

#pragma once

using namespace System;

namespace MessageFromCPP {

	public ref class CppMessage{
	public:virtual void Message(){
		Console::WriteLine("This message comes from CPP Layer");
	}
	};
}
