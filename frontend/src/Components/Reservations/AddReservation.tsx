import React, { SyntheticEvent } from 'react';

interface Props {
    onReservationCreate: (e: SyntheticEvent) => void;
    id: string;
}

const AddReservation = ( {onReservationCreate, id}: Props) => {
  return <form onSubmit={onReservationCreate} className="mt-4">
    <input readOnly={true} hidden={true} value={id} />
    <button type="submit" className="px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 transition duration-200">
      Add
    </button>
  </form>
}
export default AddReservation