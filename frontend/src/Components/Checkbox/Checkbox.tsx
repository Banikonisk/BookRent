import React from 'react'

interface Props {
    isChecked: boolean;
    onCheckboxChange: (checked: boolean) => void;
    label: string;
}

const Checkbox = ({isChecked, onCheckboxChange, label }: Props) => {

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        onCheckboxChange(e.target.checked);
    };

    return (
    <label>
        <input
            type="checkbox"
            checked={isChecked}
            onChange={handleChange}
            className="mr-2"
        />
        {label}
    </label>
    );
};

export default Checkbox