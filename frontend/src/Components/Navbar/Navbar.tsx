import React from 'react'
import { Link } from 'react-router-dom'

interface Props {}

const Navbar = (props: Props) => {
  return (
    <nav className="relative container mx-auto p-6">
      <div className="flex items-center justify-between">
        <div className="hidden font-bold lg:flex space-x-8">
          <Link to="/" className="text-black hover:text-darkBlue">
            BookRent
          </Link>
          <Link to="/reservations" className="text-black hover:text-darkBlue">
            Reservations
          </Link>
        </div>
      </div>
    </nav>
  )
}

export default Navbar