// SecondDigit.h
#include <string> 
#include <iostream>

#pragma once
using namespace std;
using namespace System;

namespace SecondDigit {

	public ref class DigitListener:FisrtDigit::DigitiListener{
		
	public:
		int EnterDigit()override{
			Console::WriteLine("Enter 2nd number>12");
			std::string s;
			std::getline(std::cin, s);
			std::string::size_type sz;
			int i_dec = std::stoi(s, &sz);
			return i_dec;
		}
	};
}
