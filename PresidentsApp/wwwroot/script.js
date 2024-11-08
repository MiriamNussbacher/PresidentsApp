const apiUrl = '/api/Presidents';

document.addEventListener('DOMContentLoaded', () => {
    loadPresidents();

    const presidentForm = document.getElementById('president-form');
    presidentForm.addEventListener('submit', handleFormSubmit);

    document.getElementById('reset-btn').addEventListener('click', resetForm);
    document.getElementById('filter-btn').addEventListener('click', filterPresidents);
    document.getElementById('clear-filter-btn').addEventListener('click', () => {
        document.getElementById('filter-date').value = '';
        loadPresidents();
    });
});

async function loadPresidents(url = apiUrl) {
    const response = await fetch(url);
    const presidents = await response.json();
    const tableBody = document.querySelector('#presidents-table tbody');
    tableBody.innerHTML = '';

    presidents.forEach(president => {
        const row = document.createElement('tr');

        row.innerHTML = `
            <td>${president.name}</td>
            <td>${new Date(president.birthdate).toLocaleDateString()}</td>
            <td>${new Date(president.inaugurationDate).toLocaleDateString()}</td>
            <td>${president.termCount}</td>
            <td class="actions">
                <button onclick="editPresident(${president.id})">Edit</button>
                <button onclick="deletePresident(${president.id})">Delete</button>
            </td>
        `;

        tableBody.appendChild(row);
    });
}

async function handleFormSubmit(event) {
    event.preventDefault();

    const president = {
        id: document.getElementById('president-id').value || 0,
        name: document.getElementById('name').value,
        birthdate: document.getElementById('birthdate').value,
        inaugurationDate: document.getElementById('inaugurationDate').value,
        termCount: parseInt(document.getElementById('termCount').value)
    };

    if (president.id == 0) {
        await fetch(apiUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(president)
        });
    } else {
        await fetch(`${apiUrl}/${president.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(president)
        });
    }

    resetForm();
    loadPresidents();
}

function resetForm() {
    document.getElementById('president-form').reset();
    document.getElementById('president-id').value = '';
}

async function editPresident(id) {
    const response = await fetch(`${apiUrl}/${id}`);
    const president = await response.json();

    document.getElementById('president-id').value = president.id;
    document.getElementById('name').value = president.name;
    document.getElementById('birthdate').value = president.birthdate.split('T')[0];
    document.getElementById('inaugurationDate').value = president.inaugurationDate.split('T')[0];
    document.getElementById('termCount').value = president.termCount;
}

async function deletePresident(id) {
    if (confirm('Are you sure you want to delete this president?')) {
        await fetch(`${apiUrl}/${id}`, { method: 'DELETE' });
        loadPresidents();
    }
}

function filterPresidents() {
    const date = document.getElementById('filter-date').value;
    if (date) {
        loadPresidents(`${apiUrl}/born-after/${date}`);
    }
}
